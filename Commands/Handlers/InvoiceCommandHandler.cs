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
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return Task.FromResult("");
        }
    }
}