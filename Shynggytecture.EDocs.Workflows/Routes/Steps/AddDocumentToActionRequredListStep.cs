using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.Core.Services.Routes.ReadDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class AddDocumentToActionRequredListStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_EmployeeId { get; set; }

        public string In_DocumentName { get; set; }

        public string In_DocumentPublicInfo { get; set; }


        private readonly IRouteReadDbService _service;

        public AddDocumentToActionRequredListStep(IRouteReadDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var documentItem = new DocumentDto()
            {
                Name = this.In_DocumentName,
                PublicInfo = this.In_DocumentPublicInfo
            };

            await _service.AddDocumentToActionRequired(new AddDocumentActionRequiredDto() 
            {
                CompanyId = this.In_CompanyId,
                EmployeeId = this.In_EmployeeId,
                DocumentId = this.In_DocumentId,
                Document = documentItem
            });

            return ExecutionResult.Next();
        }
    }
}
