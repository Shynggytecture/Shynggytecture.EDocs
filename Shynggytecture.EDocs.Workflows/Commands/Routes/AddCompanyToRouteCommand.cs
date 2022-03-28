using Shynggytecture.EDocs.Core.Commands.Routes;
using Shynggytecture.EDocs.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.Workflows.Commands.Routes
{
    public class AddCompanyToRouteCommand : IAddCompanyToRouteCommand
    {
        private readonly IWorkflowController _workflowService;

        public AddCompanyToRouteCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(AddCompanyToRouteCommandArg arg)
        {
            var documentId = arg.DocumentId.ToString();
            var companyId = arg.CompanyId;

            await _workflowService.PublishEvent(
                EventConstants.AddReceiverCompanyToRouteEvent, 
                documentId, 
                companyId);

            return documentId;
        }
    }
}
