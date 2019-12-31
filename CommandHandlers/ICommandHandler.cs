using SBA.Expense.Commands;

namespace SBA.Expense.CommandHandlers{
    public interface IWriteCommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}