using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class CheckRouteStatusStep : StepBodyAsync
    {
        public int DocumentId { get; set; }

        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
