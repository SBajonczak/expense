using System;

namespace SBA.Expense.ReadModels{
    public class InvoiceDetails
    {
        public Guid ID {get;set;}
        public string UserId {get;set;}

        public decimal Amount {get;set;}
    }
}