using System;

namespace SBA.Expense.Commands
{
    public class CommandResult
    {
        public CommandResult()
        {

        }
        public CommandResult(bool OK, Guid entityID) : this()
        {
            this.EntityID = entityID;
            this.OK = OK;

        }
        public CommandResult(bool OK, Guid entityID,string errorCode, string message) : this(OK, entityID)
        {
            this.ErrorCode = errorCode;
            this.Errors = message;
            this.EntityID = entityID;

        }
        public Guid EntityID { get; set; }
        public string ErrorCode { get; set; }
        public bool OK { get; set; }
        public string Errors { get; set; }
    }
}