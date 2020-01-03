using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Commands;
using SBA.Expense.Events;
using SBA.Expense.Models;

namespace SBA.Expense.Command.Handlers
{
    public class InvoiceCommandHandler : IRequestHandler<CreateInvoice, CommandResult>
    {
        IMediator mediator;
        InvoiceContext context;
        public InvoiceCommandHandler(InvoiceContext context, IMediator mediator)
        {
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
                        return new CommandResult(true,  invoice.ID,"ERR-1001", "ID already exists");
                    }
                    if (context.Invoices.Any(_ => _.UserId == invoice.UserId && _.Date == invoice.Date))
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        return new CommandResult(true, invoice.ID,"ERR-1002", "Invoice Entry already exists");
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
    }
}
