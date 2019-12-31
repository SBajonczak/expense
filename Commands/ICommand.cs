using System;

namespace SBA.Expense.Commands
{
    public interface ICommand{
        Guid Id{get;}
    }
}