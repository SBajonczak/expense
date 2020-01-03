using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SBA.Expense.Models;

namespace SBA.Expense.Events.Handlers
{
    public class InvoiceHandler :
    INotificationHandler<InvoiceCreatedEvent>
    {

        private readonly InvoiceContext _invoiceRepository;
        private readonly ILogger _logger;

        public InvoiceHandler(InvoiceContext invoiceRepository, ILogger<InvoiceHandler> logger)
        {
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _logger = logger;
        }

        public async Task Handle(InvoiceCreatedEvent notification, CancellationToken cancellationToken)
        {
          var invoice =  _invoiceRepository.Invoices.SingleOrDefault(_ => _.ID == notification.EntityID);

            if (invoice == null)
            {
                //TODO: Handle next business logic if customer is not found
                _logger.LogWarning("Invoice is not found by customer id from publisher");
            }
            else
            {
                _logger.LogInformation($"Invoice has found by customer id: {notification.EntityID} from publisher");
            }
        }
    }
}