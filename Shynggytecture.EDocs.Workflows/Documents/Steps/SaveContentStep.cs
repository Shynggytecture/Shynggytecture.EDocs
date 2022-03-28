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
    public class SaveContentStep : StepBodyAsync
    {
        // INPUTS
        public int In_DocumentId { get; set; }

        public string In_Content { get; set; }

        // OUTPUTS
        public string Out_Path { get; set; }

        private readonly IDocumentWriteDbService _service;

        public SaveContentStep(IDocumentWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_Path = await _service
                .SaveDocumentContentAsBlob(this.In_DocumentId, this.In_Content);

            return ExecutionResult.Next();
        }
    }
}
