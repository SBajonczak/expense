using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.Commands;
using SBA.Expense.Commands.Services;
using SBA.Expense.Models;
using SBA.Expense.Queries.Sevices;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceCommandController : ControllerBase
    {

        IInvoiceQueryService queryService;
        IInvoiceCommandService commandService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceCommandController(ILogger<InvoiceController> logger, IInvoiceQueryService queryService, IInvoiceCommandService commandService)
        {
            this.commandService = commandService;
            this.queryService= queryService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddInvoiceEntry([FromBody]CreateInvoice command){
            return Ok(await commandService.SaveInvoice(command));
        }

       
    }
}
