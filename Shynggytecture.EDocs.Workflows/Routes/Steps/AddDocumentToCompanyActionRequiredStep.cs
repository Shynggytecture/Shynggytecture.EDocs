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
    public class AddDocumentToCompanyActionRequiredStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_SenderCompanyId { get; set; }

        public List<int> In_ReceiverEmployeeIds { get; set; }

        private readonly IRouteReadDbService _service;

        public AddDocumentToCompanyActionRequiredStep(IRouteReadDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            foreach (var emplId in In_ReceiverEmployeeIds) 
            {
                await _service.AddEmployeeToHandleRouteList(
                    this.In_DocumentId, 
                    this.In_CompanyId, 
                    emplId, this.In_SenderCompanyId);
            }

            return ExecutionResult.Next();
        }
    }
}
