using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class SetCurrentCompanyRouteStep : StepBodyAsync
    {
        public CompanyRouteModel In_RouteModel { get; set; }

        public CompanyRouteModel Out_RouteModel { get; set; }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_RouteModel = this.In_RouteModel;

            return ExecutionResult.Next();
        }
    }
}
