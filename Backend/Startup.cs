using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SBA.Expense.Models;
using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SBA.Expense.Repos;

namespace SBA.Expense
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<InvoiceContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InvoiceDb"]));
            services.AddDbContext<InvoiceContext>(opts => opts.UseInMemoryDatabase(databaseName: "InvoiceDB").ConfigureWarnings(_ => _.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            services.AddMediatR(Assembly.GetExecutingAssembly());


            services.AddSingleton<IAzureBlobRepo, AzureBlobRepo>(e =>
            {
                return new AzureBlobRepo(Configuration["ConnectionString:AzureStorage"]);
            });

            services.AddControllers();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
