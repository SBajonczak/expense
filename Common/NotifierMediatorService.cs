using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Models;
using SBA.Expense.ReadModels.Commands;

namespace SBA.Expense.Common
{
    public interface IInvoiceMediatorService
{
    Task<List<Invoice>> GetInvoices(string userName);
}
 
public class INvoiceMediatorService : IInvoiceMediatorService
{
    private readonly IMediator _mediator;
 
    public INvoiceMediatorService(IMediator mediator)
    {
        _mediator = mediator;
    }
 
    public async Task<List<Invoice>> GetInvoices(string userName)
    {
        return await _mediator.Send(new GetInvoicesRequest(){UserName= userName});

    }
}
}