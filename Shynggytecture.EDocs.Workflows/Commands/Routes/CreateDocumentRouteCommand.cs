using Shynggytecture.EDocs.Core.Commands.Routes;
using Shynggytecture.EDocs.Workflows.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.Workflows.Commands.Routes
{
    public class CreateDocumentRouteCommand : ICreateDocumentRouteCommand
    {
        private readonly IWorkflowController _workflowService;

        public CreateDocumentRouteCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(CreateDocumentRouteArg arg)
        {
            var data = new RouteWorkflowData(arg.DocumentId, arg.OwnerEmployeeId, arg.SenderCompanyId);

            var id = await _workflowService.StartWorkflow("RouteWorkflow", data);

            return id;
        }
    }
}
