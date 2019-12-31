using Microsoft.EntityFrameworkCore;
using SBA.Expense.ReadModels;

namespace SBA.Expense.Models
{
    public class InvoiceContext : DbContext
    {
        public DbSet<Invoice> Invoices {get;set;}
        public DbSet<BillInformation> InvoiceDetails {get;set;}
    }
}