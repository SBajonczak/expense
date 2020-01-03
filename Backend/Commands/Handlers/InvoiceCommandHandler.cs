using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Commands;
using SBA.Expense.Events;
using SBA.Expense.Models;
using SBA.Expense.Repos;

namespace SBA.Expense.Command.Handlers
{
    public class InvoiceCommandHandler :
    IRequestHandler<CreateInvoice, CommandResult>,
    IRequestHandler<AttachReceipt, CommandResult>

    {
        IMediator mediator;
        InvoiceContext context;
        IAzureBlobRepo azureBlobRepo;
        public InvoiceCommandHandler(InvoiceContext context, IMediator mediator, IAzureBlobRepo azureBlobRepo)
        {
            this.azureBlobRepo = azureBlobRepo;
            this.mediator = mediator;
            this.context = context;
        }

        public InvoiceCommandHandler()
        {
        }


        public async Task<CommandResult> Handle(CreateInvoice notification, CancellationToken cancellationToken)
        {

            context.EventEntries.Add(new EventEntry() { ID = Guid.NewGuid(), Payload = JsonSerializer.Serialize(notification) });

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var invoice = notification.ToInVoice();

                    if (context.Invoices.Any(_ => _.ID == invoice.ID))
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        return new CommandResult(true, invoice.ID, "ERR-1001", "ID already exists");
                    }
                    if (context.Invoices.Any(_ => _.UserId == invoice.UserId && _.Date == invoice.Date))
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        return new CommandResult(true, invoice.ID, "ERR-1002", "Invoice Entry already exists");
                    }

                    await context.Invoices.AddAsync(invoice, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                    // publish creation to subscribers
                    await mediator.Publish(new InvoiceCreatedEvent(invoice.ID, invoice.Date), cancellationToken);
                    return new CommandResult(true, invoice.ID);

                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new CommandResult(false, Guid.Empty, "ERR-2000", e.Message);
                }
            }
        }

        public async Task<CommandResult> Handle(AttachReceipt request, CancellationToken cancellationToken)
        {
            context.EventEntries.Add(new EventEntry() { ID = Guid.NewGuid(), Payload = JsonSerializer.Serialize(request) });
            await this.azureBlobRepo.Store("receipts", request.UserID, request.FileName, new MemoryStream(request.Content));
            using (var transaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    Receipt r = new Receipt();
                    r.ReferenceBlobAdress = string.Concat(request.UserID, "/", request.FileName);
                    r.InvoiceID = request.InvoiceId;
                    r.UserId = request.UserID;
                    r.FileName = request.FileName;
                    await context.Receipts.AddAsync(r, cancellationToken);
                    await context.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                    // Publish Create Event to subscriber.
                    await this.mediator.Publish(new ReceiptCreatedEvent(r.ID, r.ReferenceBlobAdress),cancellationToken);
                    return new CommandResult(true, r.ID);
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new CommandResult(true, Guid.Empty, "ERR-2000", e.Message);
                }
            }
        }
    }
}
