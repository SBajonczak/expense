using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Models;

namespace SBA.Expense.Queries.Handler
{
    public class QueryHandler : IRequestHandler<GetInvoicesForUser, List<Invoice>>
    {

        InvoiceContext context;
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public QueryHandler(InvoiceContext context)
        {
            this.context = context;
        }

        Task<List<Invoice>> IRequestHandler<GetInvoicesForUser, List<Invoice>>.Handle(GetInvoicesForUser request, CancellationToken cancellationToken)
        {
            var result = this.context.Invoices.Where(_=>_.UserId == request.UserName).ToList();
            return Task.FromResult(result);
        }
    }
}