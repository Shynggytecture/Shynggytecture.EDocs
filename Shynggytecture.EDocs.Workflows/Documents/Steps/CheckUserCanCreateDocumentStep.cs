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
    public class CheckUserCanCreateDocumentStep : StepBodyAsync
    {
        // input
        public int In_EmployeeId { get; set; }

        // output
        public bool Out_CanCreateDocument { get; set; }

        private readonly IDocumentWriteDbService _service;

        public CheckUserCanCreateDocumentStep(IDocumentWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            this.Out_CanCreateDocument = await _service
                .CheckEmployeeCanCreateDocument(this.In_EmployeeId);

            return ExecutionResult.Next();
        }
    }
}
