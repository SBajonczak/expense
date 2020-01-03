using System;
using MediatR;
using SBA.Expense.Common;
using SBA.Expense.Models;

namespace SBA.Expense.Commands
{
    public class CreateInvoice : CommandBase<CommandResult>
    {
        public CreateInvoice()
        {
            this.Id = Guid.NewGuid();
        }
        public CreateInvoice(Guid objectId, string userId, DateTime date) : this()
        {
            this.Id = objectId;
            this.UserID = userId;
            this.Date = date;
        }
        public Guid Id { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }

        public Invoice ToInVoice()
        {
            Invoice item = new Invoice();
            item.ID = Guid.NewGuid();
            item.UserId = this.UserID;
            item.Date = this.Date;
            return item;
        }

    }
}