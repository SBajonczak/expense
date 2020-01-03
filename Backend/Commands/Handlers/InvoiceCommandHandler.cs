using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Commands;
using SBA.Expense.Events;
using SBA.Expense.Models;

namespace SBA.Expense.Command.Handlers
{
    public class InvoiceCommandHandler : IRequestHandler<CreateInvoice,CommandResult>
    {
        IMediator mediator;
        InvoiceContext context;
        public InvoiceCommandHandler(InvoiceContext context, IMediator mediator)
        {
            this.mediator= mediator;
            this.context = context;
        }

        public InvoiceCommandHandler()
        {
        }


        public  async Task<CommandResult> Handle(CreateInvoice notification, CancellationToken cancellationToken)
        {
            var invoice = notification.ToInVoice();
            if (context.Invoices.Any(_ => _.AggregateId == invoice.AggregateId))
            {
                invoice.Index = context.Invoices.Where(_ => _.AggregateId == invoice.AggregateId).Max(_ => _.Index) + 1;
            }
            else
            {
                invoice.InvoiceState = Invoice.State.Created;
            }
            context.Invoices.Add(invoice);
            context.SaveChanges();

            // publish creation to subscribers
            await mediator.Publish(new InvoiceCreatedEvent(invoice.ID, invoice.AggregateId, invoice.Date),cancellationToken);

            return new CommandResult(true,string.Empty, invoice.ID, invoice.AggregateId);
        }
    }
}