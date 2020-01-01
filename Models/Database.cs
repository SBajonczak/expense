using Microsoft.EntityFrameworkCore;

namespace SBA.Expense.Models
{
    public class InvoiceContext : DbContext
    {

        public InvoiceContext(){

        }
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
       : base(options)
        { }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<BillInformation> InvoiceDetails { get; set; }
    }
}