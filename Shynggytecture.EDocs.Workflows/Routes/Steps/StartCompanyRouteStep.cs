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
    public class StartCompanyRouteStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public bool Out_CompanyRouteStarted { get; set; }

        private readonly IRouteWriteDbService _service;

        public StartCompanyRouteStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.StartCompanyRoute(this.In_DocumentId, this.In_CompanyId);

            this.Out_CompanyRouteStarted = true;

            return ExecutionResult.Next();
        }
    }
}
