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
    public class AddEmployeeToCompanyRouteCommand : IAddEmployeeToCompanyRouteCommand
    {
        private readonly IWorkflowController _workflowService;

        public AddEmployeeToCompanyRouteCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(AddEmployeeToCompanyRouteCommandArg arg)
        {
            var documentId = arg.DocumentId.ToString();
            var employeeId = arg.EmployeeId;

            if (!arg.CompanyId.HasValue)
            {
                await _workflowService.PublishEvent(
                    EventConstants.AddSenderEmployeeToCompanyRouteEvent,
                    documentId,
                    employeeId);
            }
            else 
            {
                var companyId = arg.CompanyId.Value;
                await _workflowService.PublishEvent(
                    EventConstants.AddReceiverEmployeeToCompanyRouteEvent,
                    $"{documentId}_{companyId}",
                    employeeId);
            }

            return documentId;
        }
    }
}
