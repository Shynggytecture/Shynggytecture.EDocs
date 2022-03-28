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
    public class AddEmployeeToCompanyRouteStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_EmployeeId { get; set; }

        public List<int> In_EmployeeIds { get; set; }

        public List<int> Out_EmployeeIds { get; set; }

        private readonly IRouteWriteDbService _service;

        public AddEmployeeToCompanyRouteStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (In_EmployeeIds == null) 
            {
                In_EmployeeIds = new List<int>();
            }

            await _service.AddEmployeeToCompanyRoute(new Core.Services.Routes.WriteDbDtos.AddEmployeeToCompanyRouteDto() 
            {
                CompanyId = this.In_CompanyId,
                DocumentId = this.In_DocumentId,
                EmployeeId = this.In_EmployeeId
            });

            this.In_EmployeeIds.Add(this.In_EmployeeId);

            this.Out_EmployeeIds = this.In_EmployeeIds.ToList();

            return ExecutionResult.Next();
        }
    }
}
