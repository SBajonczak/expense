using SBA.Expense.Commands;

namespace SBA.Expense.CommandHandlers{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}