using Microsoft.EntityFrameworkCore;

namespace SBA.Expense.Models
{
    public class InvoiceContext : DbContext
    {

        public InvoiceContext()
        {

        }
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
       : base(options)
        {

            this.Database.EnsureCreated();
        }


        public DbSet<EventEntry> EventEntries { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
    }
}