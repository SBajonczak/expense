using System;

namespace SBA.Expense.Common{

    public interface IEventSourceingObject{
        Guid GroupID{get;set;}
        int Index{get;set;}
        
    }
}