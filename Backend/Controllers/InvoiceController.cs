using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBA.Expense.Commands.Services;
using SBA.Expense.Models;
using SBA.Expense.Queries.Sevices;

namespace SBA.Expense.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {

        IInvoiceQueryService queryService;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger, IInvoiceQueryService queryService )
        {
            this.queryService = queryService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<List<Invoice>> Get([FromQuery] string username)
        {
            return await queryService.GetInvoices(username);
        }
    }
}
