using Microsoft.Extensions.DependencyInjection;
using Shynggytecture.EDocs.Core.Commands.Documents;
using Shynggytecture.EDocs.Core.Commands.Routes;
using Shynggytecture.EDocs.Core.Services.Documents;
using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.Workflows.Commands.Documents;
using Shynggytecture.EDocs.Workflows.Commands.Routes;
using Shynggytecture.EDocs.Workflows.Documents.Steps;
using Shynggytecture.EDocs.Workflows.Routes.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Workflows
{
    public static class ServiceCollectionRegister
    {
        public static IServiceCollection AddWorkflowSteps(this IServiceCollection services) 
        {
            services.AddTransient<ICreateDocumentCommand, CreateDocumentCommand>();

            services.AddTransient<IAcceptDocumentCommand, AcceptDocumentCommand>();
            services.AddTransient<IAddCompanyToRouteCommand, AddCompanyToRouteCommand>();
            services.AddTransient<IAddEmployeeToCompanyRouteCommand, AddEmployeeToCompanyRouteCommand>();
            services.AddTransient<ICreateDocumentRouteCommand, CreateDocumentRouteCommand>();
            services.AddTransient<IStartCompanyRouteCommand, StartCompanyRouteCommand>();

            services.AddTransient<CheckUserCanCreateDocumentStep>();
            services.AddTransient<CleanUpDocumentStep>();
            services.AddTransient<NotifyNewDocumentCreatedStep>();
            services.AddTransient<SaveContentStep>();
            services.AddTransient<SaveDocumentInWriteDbStep>();
            services.AddTransient<SaveDocumentInReadDbStep>();
            services.AddTransient<UpdateDocumentPathStep>();

            services.AddTransient<AcceptCompanyRouteByEmployeeStep>();
            services.AddTransient<AddCompanyRouteStep>();
            services.AddTransient<AddDocumentToActionRequredListStep>();
            services.AddTransient<AddDocumentToCompanyActionRequiredStep>();
            services.AddTransient<AddEmployeeToCompanyRouteStep>();
            services.AddTransient<CheckRouteStatusStep>();
            services.AddTransient<CreateRouteStep>();
            services.AddTransient<FinishDocumentStep>();
            services.AddTransient<GetCompanyRouteStatusStep>();
            services.AddTransient<GetCompayHeadersTask>();
            services.AddTransient<GetDocumentStep>();
            services.AddTransient<NotifyRequiredEmployeeActionStep>();
            services.AddTransient<NotifyRequredCompanyActionStep>();
            services.AddTransient<NotifyRouteFinishedStep>();
            services.AddTransient<PrepareRouteStep>();
            services.AddTransient<RemoveDocumentFromActionRequiredListStep>();
            services.AddTransient<SetCurrentCompanyRouteStep>();
            services.AddTransient<SetRouteStatusStep>();
            services.AddTransient<StartCompanyRouteStep>();
            services.AddTransient<StartRouteStep>();

            return services;
        }
    }
}
