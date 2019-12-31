using System;
using SBA.Expense.Models;
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
        public DateTime Date {get;set;}

        public Invoice ToInVoice(){
            Invoice  item = new Invoice();
            item.ID= this.Id;
            item.UserId= this.UserID;
            item.Date = this.Date;
            return item;
        }

    }
}