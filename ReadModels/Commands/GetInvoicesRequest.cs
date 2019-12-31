using System;
using System.Collections.Generic;
using MediatR;
using SBA.Expense.Commands;
using SBA.Expense.Models;

namespace SBA.Expense.ReadModels.Commands
{
    public class GetInvoicesRequest : IRequest<List<Invoice>> {
        public string UserName {get;set;}

     }
}