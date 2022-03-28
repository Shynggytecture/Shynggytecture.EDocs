using Shynggytecture.EDocs.Core.Services.Documents;
using Shynggytecture.EDocs.Core.Services.Documents.ReadDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Documents.Steps
{
    public class SaveDocumentInReadDbStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        public int In_OwnerEmployeeId { get; set; }

        public string In_Name { get; set; }

        public string In_PublicInformation { get; set; }

        public string In_PrivateInformation { get; set; }

        public string In_Path { get; set; }

        public int Out_CreatedItemId { get; set; }

        private readonly IDocumentReadDbService _service;

        public SaveDocumentInReadDbStep(IDocumentReadDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_CreatedItemId = await _service
                .CreateOwnedDocument(new CreateOwnedDbDto() 
                {
                    CompanyId = this.In_CompanyId,
                    DocumentId = this.In_DocumentId,
                    Name = this.In_Name,
                    OwnerEmployeeId = this.In_OwnerEmployeeId,
                    Path = this.In_Path,
                    PrivateInformation = this.In_PrivateInformation,
                    PublicInformation = this.In_PublicInformation
                });

            return ExecutionResult.Next();
        }
    }
}
