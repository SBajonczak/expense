using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.Commands;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceCommandController : ControllerBase
    {

        private readonly ILogger<InvoiceController> _logger;
        IMediator _mediator;

        public InvoiceCommandController(ILogger<InvoiceController> logger, IMediator mediator)
        {
            this._mediator = mediator;

            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AddInvoiceEntry([FromBody]CreateInvoice command)
        {

            CommandResult result = await _mediator.Send(command);
            if (result.OK)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }


        }



    }
}
