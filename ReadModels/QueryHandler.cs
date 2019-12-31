using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SBA.Expense.Models;
using SBA.Expense.ReadModels.Commands;

namespace SBA.Expense.ReadModels
{
    public class QueryHandler : IRequestHandler<GetInvoicesRequest, List<Invoice>>
    {
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

        Task<List<Invoice>> IRequestHandler<GetInvoicesRequest, List<Invoice>>.Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            var result = new List<Invoice>();
            result.Add(new Invoice(){UserId = request.UserName});
            result.Add(new Invoice(){UserId = request.UserName});
            result.Add(new Invoice(){UserId = request.UserName});
            return  Task.FromResult(result);
        }
    }
}