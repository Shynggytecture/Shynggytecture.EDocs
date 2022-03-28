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
    public class UpdateDocumentPathStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public string In_DocumentPath { get; set; }

        private readonly IDocumentWriteDbService _service;

        public UpdateDocumentPathStep(IDocumentWriteDbService service)
        {
            _service = service;
        }
        
        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await _service.UpdateDocumentPath(this.In_DocumentId, this.In_DocumentPath);

            return ExecutionResult.Next();
        }
    }
}
