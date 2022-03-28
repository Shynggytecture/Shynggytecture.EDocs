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
    public class AcceptDocumentCommand : IAcceptDocumentCommand
    {
        private readonly IWorkflowController _workflowService;

        public AcceptDocumentCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(AcceptDocumentCommandArg arg)
        {
            var documentId = arg.DocumentId.ToString();
            var employeeId = arg.EmployeeId;

            if (!arg.CompanyId.HasValue)
            {                
                await _workflowService.PublishEvent(
                    EventConstants.AcceptSenderCompanyRouteByEmployeeEvent,
                    $"{documentId}_{employeeId}",
                    null);
            }
            else 
            {
                var companyId = arg.CompanyId.Value;

                await _workflowService.PublishEvent(
                    EventConstants.AcceptReceiverCompanyRouteByEmployee,
                    $"{documentId}_{companyId}_{employeeId}",
                    employeeId);
            }

            return documentId;
        }
    }
}
