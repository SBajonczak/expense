using MediatR;

namespace SBA.Expense.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
}