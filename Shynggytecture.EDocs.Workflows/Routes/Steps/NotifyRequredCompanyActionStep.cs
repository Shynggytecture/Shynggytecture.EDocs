using Shynggytecture.EDocs.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class NotifyRequredCompanyActionStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public int In_CompanyId { get; set; }

        private readonly NotificationService _service;

        public NotifyRequredCompanyActionStep(NotificationService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            _service
                .AddMessage("New Document for your Company")
                .AddMessage($"CompanyId: {In_CompanyId}")
                .AddMessage($"DocumentId: {In_DocumentId}")
                .Write();

            return ExecutionResult.Next();
        }
    }
}
