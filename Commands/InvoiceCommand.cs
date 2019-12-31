using System;
using SBA.Expense.ReadModels;

namespace SBA.Expense.Commands
{
    public class AddInvoiceEntry : ICommand
    {
        public AddInvoiceEntry(){
            this.Id= Guid.NewGuid();
        }
        public Guid Id {get;set;}
        public string UserID {get;set;}
        public byte[] InvoiceContent{get;set;}
        public decimal Amount {get;set;}

        public InvoiceDetails ToInvoiceDetails(){
            InvoiceDetails  item = new InvoiceDetails();
            item.ID= this.Id;
            item.UserId= this.UserID;
            item.Amount = this.Amount;
            return item;
        }

    }
}