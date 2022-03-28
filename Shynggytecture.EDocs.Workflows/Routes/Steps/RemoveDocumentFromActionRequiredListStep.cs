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
    public class RemoveDocumentFromActionRequiredListStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_EmployeeId { get; set; }

        private readonly IRouteReadDbService _service;

        public RemoveDocumentFromActionRequiredListStep(IRouteReadDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.RemoveDocumentFromActionRequired(
                this.In_DocumentId, 
                this.In_CompanyId, 
                this.In_EmployeeId);

            return ExecutionResult.Next();
        }
    }
}
