using Shynggytecture.EDocs.Core;
using Shynggytecture.EDocs.Core.Services.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class NotifyRouteFinishedStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        private readonly IRouteWriteDbService _routeService;
        private readonly NotificationService _notificationService;

        public NotifyRouteFinishedStep(
            IRouteWriteDbService routeService,
            NotificationService notificationService)
        {
            _routeService = routeService;
            _notificationService = notificationService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var ids = await _routeService.GetAllEmployeesFromDocument(this.In_DocumentId);

            foreach(var item in ids)
            {
                this._notificationService
                    .AddMessage("Document finished!")
                    .AddMessage($"DocumentId: {this.In_DocumentId}")
                    .AddMessage($"Employee: {item}")
                    .Write();
            }

            return ExecutionResult.Next();
        }
    }
}
