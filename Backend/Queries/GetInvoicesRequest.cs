using System.Collections.Generic;
using MediatR;
using SBA.Expense.Models;

namespace SBA.Expense.Queries
{
    public class GetInvoicesForUser : IRequest<List<Invoice>> {
        public string UserName {get;set;}

     }
}