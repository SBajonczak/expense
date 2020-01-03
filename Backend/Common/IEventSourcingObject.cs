using System;

namespace SBA.Expense.Common{

    public interface IEventSourceingObject{
        Guid AggregateId{get;set;}
        int Index{get;set;}
        
    }
}