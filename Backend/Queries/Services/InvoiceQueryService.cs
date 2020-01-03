using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Models;

namespace SBA.Expense.Queries.Sevices
{
    public interface IInvoiceQueryService
    {
        Task<List<Invoice>> GetInvoices(string userName);
    }

    public class InvoiceQueryService : IInvoiceQueryService
    {
        private readonly IMediator _mediator;

        public InvoiceQueryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Invoice>> GetInvoices(string userName)
        {
            var result=  await _mediator.Send(new GetInvoicesForUser() { UserName = userName });
            return result;
        }
    }
}