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
    public class StartRouteStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public bool Out_RouteStarted { get; set; }

        private readonly IRouteWriteDbService _service;

        public StartRouteStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.StartRoute(this.In_DocumentId);

            this.Out_RouteStarted = true;

            return ExecutionResult.Next();
        }
    }
}
