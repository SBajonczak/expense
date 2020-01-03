using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SBA.Expense.Common;

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
        [Key]
        public Guid ID { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public State InvoiceState { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Total { get; set; }

        public List<Receipt> Receipts { get; set; }

        public Invoice()
        {
            this.Receipts = new List<Receipt>();
        }
    }
}