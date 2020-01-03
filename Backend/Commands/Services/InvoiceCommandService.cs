using System;
using System.Threading.Tasks;
using MediatR;

namespace SBA.Expense.Commands.Services
{
    public interface IInvoiceCommandService
    {
        Task<CommandResult> SaveInvoice(CreateInvoice command);
    }

    public class InvoiceCommandService : IInvoiceCommandService
    {
        private readonly IMediator _mediator;

        public InvoiceCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> SaveInvoice(CreateInvoice command)
        {
            return await _mediator.Send(command);
        }
    }
}