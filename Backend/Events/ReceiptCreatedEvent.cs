using System;
using MediatR;

namespace SBA.Expense.Events
{
    public class ReceiptCreatedEvent:INotification{

        public ReceiptCreatedEvent(Guid entityID, string blobReferencePath){
            this.EntityID = entityID;
            this.BlobReferencePath = blobReferencePath;
        }

        public Guid EntityID {get;set;}

        public string BlobReferencePath{get;set;}

    }
}