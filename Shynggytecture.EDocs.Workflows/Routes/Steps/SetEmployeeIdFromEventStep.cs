using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class SetEmployeeIdFromEventStep : StepBody
    {
        public int In_EmployeeId { get; set; }

        public int Out_EmployeeId { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            this.Out_EmployeeId = this.In_EmployeeId;

            return ExecutionResult.Next();
        }
    }
}
