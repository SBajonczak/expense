using System.Collections.Generic;
using SBA.Expense.Commands;
using SBA.Expense.ReadModels;

namespace SBA.Expense.CommandHandlers
{
    public class InvoiceCommandHandler : ICommandHandler<AddInvoiceEntry>
    {

        public List<InvoiceDetails> Data;
        public InvoiceCommandHandler()
        {
            this.Data = new List<InvoiceDetails>();
        }

        public void Handle(AddInvoiceEntry command)
        {
            Data.Add(command.ToInvoiceDetails());
        }
    }
}