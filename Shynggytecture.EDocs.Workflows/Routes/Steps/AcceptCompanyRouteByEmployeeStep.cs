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
    public class AcceptCompanyRouteByEmployeeStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_EmployeeId { get; set; }

        private readonly IRouteWriteDbService _service;

        public AcceptCompanyRouteByEmployeeStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.AcceptRouteByEmployee(
                this.In_DocumentId,
                this.In_CompanyId,
                this.In_EmployeeId);

            return ExecutionResult.Next();
        }
    }
}
