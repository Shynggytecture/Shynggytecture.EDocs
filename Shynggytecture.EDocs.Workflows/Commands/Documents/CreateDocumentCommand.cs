using Shynggytecture.EDocs.Core.Commands.Documents;
using Shynggytecture.EDocs.Workflows.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace Shynggytecture.EDocs.Workflows.Commands.Documents
{
    public class CreateDocumentCommand : ICreateDocumentCommand
    {
        private readonly IWorkflowController _workflowService;

        public CreateDocumentCommand(IWorkflowController workflowService)
        {
            _workflowService = workflowService;
        }

        public async Task<string> Handle(CreateDocumentCommandArg arg)
        {
            var data = new DocumentWorkflowData(arg.CompanyId, arg.EmployeeOwnerId, arg.Name, arg.Content, arg.PublicInformation, arg.PrivateInformation);

            var id = await _workflowService.StartWorkflow("DocumentWorkflow", data);

            return id;
        }
    }
}
