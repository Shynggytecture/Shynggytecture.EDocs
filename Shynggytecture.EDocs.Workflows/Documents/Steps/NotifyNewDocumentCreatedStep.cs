using Shynggytecture.EDocs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Documents.Steps
{
    public class NotifyNewDocumentCreatedStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_EmployeeId { get; set; }

        private readonly NotificationService _service;

        public NotifyNewDocumentCreatedStep(NotificationService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            _service
                .AddMessage("New Document created!")
                .AddMessage($"EmployeeId: {In_EmployeeId}")
                .AddMessage($"DocumentId: {In_DocumentId}")
                .Write();
            
            return ExecutionResult.Next();
        }
    }
}
