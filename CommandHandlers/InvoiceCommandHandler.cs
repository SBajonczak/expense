using System.Collections.Generic;
using SBA.Expense.Commands;
using SBA.Expense.Models;
using SBA.Expense.ReadModels;

namespace SBA.Expense.CommandHandlers
{
    public class InvoiceCommandHandler : IWriteCommandHandler<AddInvoiceEntry>
    {

        InvoiceContext context;
        public InvoiceCommandHandler(InvoiceContext context)
        {
            this.context= context;
        }

        public async void Handle(AddInvoiceEntry command)
        {

            var invoice = command.ToInVoice();
            await context.Invoices.AddAsync(command.ToInVoice());
            

        }
    }
}