using System;

namespace SBA.Expense.Models{
    public class BillInformation
    {
        public Guid ID {get;set;}
        public string Comment {get;set;}
        public string Type {get;set;}
        public decimal Total {get;set;}
        public string ReferenceBlobAdress {get;set;}
    }
}