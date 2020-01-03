using System;
using MediatR;
using SBA.Expense.Common;
using SBA.Expense.Models;

namespace SBA.Expense.Commands
{
    public class AttachReceipt : CommandBase<CommandResult>
    {
        public AttachReceipt()
        {
            this.Id = Guid.NewGuid();
        }
        public AttachReceipt(Guid entityID, Guid invoiceID, string userId, byte[] content) : this()
        {
            this.Id = entityID;
            this.UserID = userId;
            this.InvoiceId = invoiceID;
            this.Content= content;
        }
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public Guid InvoiceId { get; set; }
        public decimal Amount {get;set;}
        public byte[] Content{get;set;}

        public string FileName {get;set;}

    }
}