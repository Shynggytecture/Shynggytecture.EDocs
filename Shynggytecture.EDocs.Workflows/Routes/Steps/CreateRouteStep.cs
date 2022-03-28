using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.Core.Services.Routes.WriteDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class CreateRouteStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_EmployeeId { get; set; }

        private readonly IRouteWriteDbService _service;

        public CreateRouteStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.CreateRoute(new CreateRouteDto() 
            {
                CompanyId = this.In_CompanyId,
                DocumentId = this.In_DocumentId,
                EmployeeId = this.In_EmployeeId
            });

            return ExecutionResult.Next();
        }
    }
}
