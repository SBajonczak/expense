using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System;
using System.Threading.Tasks;
using SBA.Expense.ReadModels;
using Microsoft.EntityFrameworkCore;
using SBA.Expense.Models;
using MediatR;
using MediatR.Pipeline;
using System.IO;
using SBA.Expense.ReadModels.Commands;
using System.Reflection;
using SBA.Expense.Common;

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


            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IInvoiceMediatorService, INvoiceMediatorService>();

            // services.AddDbContext<InvoiceContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:InvoiceDb"]));
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
