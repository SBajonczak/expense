using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.CommandHandlers;
using SBA.Expense.Commands;
using SBA.Expense.Common;
using SBA.Expense.Models;
using SBA.Expense.ReadModels.Commands;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {

        IInvoiceMediatorService mediator;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceMediatorService mediator)
        {
            this.mediator= mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task AddInvoice([FromQuery] string username){
            var r = await mediator.GetInvoices(username);
            
        }
    }
}
