using System;

namespace SBA.Expense.Commands
{
    public class CommandResult
    {
        public CommandResult(){

        }

        public CommandResult(bool OK, string errors, Guid entityID, Guid aggregateID):this(){
            this.OK= OK;
            this.Errors = errors;
            this.EntityID= entityID;
            this.AggregateID= aggregateID;
        }
        public Guid EntityID {get;set;}

        public Guid AggregateID {get;set;}
        public bool OK {get;set;}
        public string Errors {get;set;}
    }
}