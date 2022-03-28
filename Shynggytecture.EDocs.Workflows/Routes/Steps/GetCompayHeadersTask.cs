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
    public class GetCompayHeadersTask : StepBodyAsync
    {
        public int In_CompanyId { get; set; }

        public List<int> Out_CompanyHeadEmployeeIds { get; set; }

        private readonly IRouteWriteDbService _service;

        public GetCompayHeadersTask(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_CompanyHeadEmployeeIds = await _service
                .GetCompanyHeadEmployeeIds(this.In_CompanyId);

            return ExecutionResult.Next();
        }
    }
}
