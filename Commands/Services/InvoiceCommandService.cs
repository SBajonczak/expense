using System;
using System.Threading.Tasks;
using MediatR;

namespace SBA.Expense.Commands.Services
{
    public interface IInvoiceCommandService
    {
        Task SaveInvoice(Guid objectId, string userID, DateTime date);
    }

    public class InvoiceCommandService : IInvoiceCommandService
    {
        private readonly IMediator _mediator;

        public InvoiceCommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SaveInvoice(Guid objectID, string userID, DateTime date)
        {
            await _mediator.Publish(new CreateInvoice(objectID, userID, date));
        }
    }
}