using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Shynggytecture.EDocs.Core;
using Shynggytecture.EDocs.Core.Services.Documents;
using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.DataModel.EfCore;
using Shynggytecture.EDocs.DataModel.EfCore.Services;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Documents;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Routes;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Services;
using Shynggytecture.EDocs.WebAPI.EdmModels;
using Shynggytecture.EDocs.Workflows;
using Shynggytecture.EDocs.Workflows.Documents;
using Shynggytecture.EDocs.Workflows.Routes;
using System;
using System.Linq;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.WebAPI
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
            services.AddTransient<NotificationService>();

            services.AddControllers()
                .AddNewtonsoftJson();
            
            services.AddOData();

            services.AddTransient<IDocumentWriteDbService, DocumentWriteDbService>();
            services.AddTransient<IRouteWriteDbService, RouteWriteDbService>();

            services.AddTransient<IDocumentReadDbService, DocumentReadDbService>();
            services.AddTransient<IRouteReadDbService, RouteReadDbService>();

            services.AddDbContext<EDocsCommandContext>(options => 
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("WriteDbConnection"))
                    .EnableSensitiveDataLogging(true)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddDbContext<DocumentsDbContext>(options =>
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("ReadDocumentsDbConnection"))
                    .EnableSensitiveDataLogging(true)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddDbContext<RoutesDbContext>(options =>
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("ReadRoutesDbConnection"))
                    .EnableSensitiveDataLogging(true)
                    .LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddWorkflowSteps();

            services.AddWorkflow(options =>
            {
                var workflowcoreSettings = Configuration.GetSection("WorkflowCoreSettings");
                var connectionString = workflowcoreSettings.GetSection("AzureCosmosDbConnectionString").Value;
                var databaseId = workflowcoreSettings.GetSection("AzureCosmosDbDatabaseId").Value;

                options.UseCosmosDbPersistence(connectionString, databaseId);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shynggytecture.EDocs.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shynggytecture.EDocs.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Select().Filter().Expand().Count().OrderBy().MaxTop(10);
                endpoints.EnableDependencyInjection();
                endpoints.MapODataRoute("odata_write_queries", "odata/write", WriteEdmModelProvider.GetEdmModel());
                endpoints.MapODataRoute("odata_read_routes", "odata/read/routes", ReadRouteEdmModelProvider.GetEdmModel());
                endpoints.MapODataRoute("odata_read_documents", "odata/read/documents", ReadDocumentsEdmModelProvider.GetEdmModel());
                endpoints.MapControllers();
            });

            // run workflow core
            var host = app.ApplicationServices.GetService<IWorkflowHost>();

            host.RegisterWorkflow<DocumentWorkflow, DocumentWorkflowData>();
            host.RegisterWorkflow<RouteWorkflow, RouteWorkflowData>();

            host.Start();
        }
    }
}
