using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SBA.Expense.Models{
    [Table("Receipts")]
    public class Receipt
    {
        public Guid ID {get;set;}
        public string Comment {get;set;}
        public string Type {get;set;}
        public Guid InvoiceID {get;set;}
        public string FileName {get;set;}
        public string UserId {get;set;}
        public string ReferenceBlobAdress {get;set;}
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Amount {get;set;}
    }
}