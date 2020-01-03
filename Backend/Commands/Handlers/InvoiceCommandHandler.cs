using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Commands;
using SBA.Expense.Models;

namespace SBA.Expense.Command.Handlers
{
    public class InvoiceCommandHandler : INotificationHandler<CreateInvoice>
    {

        InvoiceContext context;
        public InvoiceCommandHandler(InvoiceContext context)
        {
            this.context = context;
        }

        public InvoiceCommandHandler()
        {
        }


        public Task Handle(CreateInvoice notification, CancellationToken cancellationToken)
        {
            var invoice = notification.ToInVoice();
            if (context.Invoices.Any(_ => _.GroupID == invoice.GroupID))
            {
                invoice.Index = context.Invoices.Where(_ => _.GroupID == invoice.GroupID).Max(_ => _.Index) + 1;
            }
            else
            {
                invoice.InvoiceState = Invoice.State.Created;
            }
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return Task.FromResult("");
        }
    }
}