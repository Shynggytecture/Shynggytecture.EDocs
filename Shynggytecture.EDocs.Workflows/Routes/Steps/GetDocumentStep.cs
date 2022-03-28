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
    public class GetDocumentStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        public string Out_DocumentName { get; set; }

        public string Out_DocumentPublicInfo { get; set; }

        private readonly IRouteWriteDbService _service;

        public GetDocumentStep(IRouteWriteDbService service)
        {
            _service = service;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var document = await _service.GetDocument(this.In_DocumentId);

            this.Out_DocumentName = document.Name;
            this.Out_DocumentPublicInfo = document.PublicInfo;

            return ExecutionResult.Next();
        }
    }
}
