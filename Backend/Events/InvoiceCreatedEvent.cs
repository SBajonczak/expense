using System;
using MediatR;

namespace SBA.Expense.Events
{
    public class InvoiceCreatedEvent:INotification{

        public InvoiceCreatedEvent(Guid entityID, DateTime date){
            this.EntityID = entityID;
            this.Date = date;
        }

        public Guid EntityID {get;set;}

        public DateTime Date {get;set;}
    }
}