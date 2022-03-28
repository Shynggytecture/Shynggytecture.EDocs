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
    public class AddCompanyRouteStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public List<int> In_CompanyIds { get; set; }

        public List<int> Out_CompanyIds { get; set; }

        private readonly IRouteWriteDbService _service;

        public AddCompanyRouteStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            if (this.In_CompanyIds == null)
            {
                this.In_CompanyIds = new List<int>();
            }

            await _service.AddCompanyToRoute(new AddCompanyToRoute() 
            {
                CompanyId = this.In_CompanyId,
                DocumentId = this.In_DocumentId
            });

            this.In_CompanyIds.Add(this.In_CompanyId);

            this.Out_CompanyIds = this.In_CompanyIds.ToList();

            return ExecutionResult.Next();
        }
    }
}
