using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.Commands;
using SBA.Expense.Controllers.Parameters;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptCommandController : ControllerBase
    {

        private readonly ILogger<InvoiceController> _logger;
        IMediator _mediator;

        public ReceiptCommandController(ILogger<InvoiceController> logger, IMediator mediator)
        {
            this._mediator = mediator;

            _logger = logger;
        }


        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Add([FromForm]UploadRequest request)
        {
            CommandResult result = await _mediator.Send(request.ToAttachReceipt());
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
