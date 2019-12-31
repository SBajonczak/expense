using System;
using System.Collections.Generic;

namespace SBA.Expense.Models
{
    public class Invoice
    {
        public enum State
        {
            Created = 0,
            PassedIn = 1,
            Paid = 2
        }

        public Guid ID { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public State InvoiceState { get; set; }
        public decimal Total { get; set; }

        public List<BillInformation> Bills{get;set;} 

        public Invoice(){
            this.Bills= new List<BillInformation>();
        }
    }
}