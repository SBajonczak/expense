using System;
using MediatR;

namespace SBA.Expense.Events
{
    public class InvoiceCreatedEvent:INotification{

        public InvoiceCreatedEvent(Guid entityID,Guid aggregateID, DateTime date){
            this.EntityID = entityID;
            this.AggregateID = aggregateID;
            this.Date = date;
        }

        public Guid EntityID {get;set;}

        public Guid AggregateID {get;set;}

        public DateTime Date {get;set;}
    }
}