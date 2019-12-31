using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.CommandHandlers;
using SBA.Expense.Commands;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {

        public InvoiceCommandHandler commandHandler;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
            commandHandler= new InvoiceCommandHandler();
        }

        [HttpPost]
        public void AddInvoice([FromQuery] string username){
            AddInvoiceEntry command = new AddInvoiceEntry();
            command.UserID= username;
            commandHandler.Handle(command);
        }
    }
}
