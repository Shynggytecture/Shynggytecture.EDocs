using Shynggytecture.EDocs.Core.Services.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Documents.Steps
{
    public class SaveDocumentInWriteDbStep : StepBodyAsync
    {
        // INPUTS
        public int In_EmployeeId { get; set; }

        public string In_Name { get; set; }

        public string In_PublicInformation { get; set; }

        public string In_PrivateInformation { get; set; }

        // OUTPUTS
        public int Out_DocumentId { get; set; }

        private readonly IDocumentWriteDbService _service;

        public SaveDocumentInWriteDbStep(IDocumentWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_DocumentId = await _service
                .CreateDocument(
                    this.In_Name,
                    this.In_EmployeeId,
                    this.In_PublicInformation,
                    this.In_PrivateInformation);

            return ExecutionResult.Next();
        }
    }
}
