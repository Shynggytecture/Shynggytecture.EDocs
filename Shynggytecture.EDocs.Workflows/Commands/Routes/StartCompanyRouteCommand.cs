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
    public class StartCompanyRouteCommand : IStartCompanyRouteCommand
    {
        private readonly IWorkflowController _workflowService;

        public StartCompanyRouteCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(StartCompanyRouteArg arg)
        {
            var documentId = arg.DocumentId.ToString();

            if (!arg.CompanyId.HasValue)
            {
                await _workflowService.PublishEvent(
                    EventConstants.StartSenderRouteEvent,
                    documentId,
                    null);
            }
            else 
            {
                var companyId = arg.CompanyId.Value;
                await _workflowService.PublishEvent(
                    EventConstants.StartReceiverRouteEvent,
                    $"{documentId}_{companyId}",
                    null);
            }

            return documentId;
        }
    }
}
