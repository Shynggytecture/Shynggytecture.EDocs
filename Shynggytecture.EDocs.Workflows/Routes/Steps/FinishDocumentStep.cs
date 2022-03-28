using Shynggytecture.EDocs.Core.Services.Documents;
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
    public class FinishDocumentStep : StepBodyAsync
    {
        public int In_DocumentId { get; set; }

        private readonly IDocumentReadDbService _readDbService;
        private readonly IRouteWriteDbService _writeDbService;

        public FinishDocumentStep(
            IDocumentReadDbService readDbService,
            IRouteWriteDbService writeDbService)
        {
            _readDbService = readDbService;
            _writeDbService = writeDbService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var routeData = await _writeDbService.GetDocumentRoutes(this.In_DocumentId);

            // inbox flow
            var inbox = routeData.Where(x => x.CompanyId != x.CompanySenderId)
                .SelectMany(x => x.EmployeeIds.Select(f => new 
                {
                    EmployeeId = f,
                    CompanyId = x.CompanyId,
                    SenderCompanyId = x.CompanySenderId,
                    DocumentId = x.DocumentId,
                    DocumentName = x.DocumentName,
                    DocumentPublicInfo = x.DocumentPublicInfo
                }))
                .ToList();

            foreach (var item in inbox) 
            {
                await _readDbService.AddDocumentToInbox(
                    item.DocumentId, 
                    item.DocumentName, 
                    item.DocumentPublicInfo, 
                    item.CompanyId, 
                    item.EmployeeId, 
                    item.SenderCompanyId);
            }

            // outbox flow
            var outbox = routeData.Where(x => x.CompanyId == x.CompanySenderId)
                .SelectMany(x => x.EmployeeIds.Select(f => new
                {
                    EmployeeId = f,
                    CompanyId = x.CompanyId,
                    SenderCompanyId = x.CompanySenderId,
                    DocumentId = x.DocumentId,
                    DocumentName = x.DocumentName,
                    DocumentPublicInfo = x.DocumentPublicInfo
                }))
                .GroupBy(x => new 
                {
                    x.EmployeeId,
                    x.SenderCompanyId,
                    x.DocumentId,
                    x.DocumentName,
                    x.DocumentPublicInfo
                })
                .ToList();

            foreach (var item in outbox)
            {
                await _readDbService.AddDocumentToOutbox(
                    item.Key.DocumentId,
                    item.Key.DocumentName,
                    item.Key.DocumentPublicInfo,
                    item.Key.SenderCompanyId,
                    item.Key.EmployeeId,
                    item.Select(f => f.CompanyId).ToList());
            }

            return ExecutionResult.Next();
        }
    }
}
