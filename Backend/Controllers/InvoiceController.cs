using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.Models;
using SBA.Expense.Queries;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {

        IMediator mediator;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger, IMediator mediator )
        {
            this.mediator = mediator;
            _logger = logger;
        }


        [HttpGet]
        public async Task<List<Invoice>> Get([FromQuery] string username)
        {
     
            return await mediator.Send(new GetInvoicesForUser(){UserName= username});
        }
    }
}
