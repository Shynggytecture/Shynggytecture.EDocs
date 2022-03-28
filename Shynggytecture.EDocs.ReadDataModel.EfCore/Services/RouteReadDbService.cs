using Microsoft.EntityFrameworkCore;
using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.Core.Services.Routes.ReadDbDtos;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Services
{
    public class RouteReadDbService : IRouteReadDbService
    {
        private readonly RoutesDbContext _dbContext;

        public RouteReadDbService(RoutesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDocumentToActionRequired(AddDocumentActionRequiredDto item)
        {
            var nItem = new ActionRequiredDocument() 
            {
                DocumentId = item.DocumentId,
                EmployeeId = item.EmployeeId,
                SenderCompanyId = item.CompanyId,
                DocumentName = item.Document.Name,
                DocumentPublicInformation = item.Document.PublicInfo,
                DocumentCreatedOn = DateTime.Now
            };

            _dbContext.ActionRequiredDocuments.Add(nItem);
            await _dbContext.SaveChangesAsync();
        }

        public Task AddEmployeeToHandleRouteList(int documentId, int companyId, int employeeId, int senderCompanyId)
        {
            _dbContext.DocumentInboxRoutes.Add(new DocumentInboxRoute() 
            {
                CompanyId = companyId,
                DocumentId = documentId,
                EmployeeId = employeeId,
                SenderCompanyId = senderCompanyId
            });

            return _dbContext.SaveChangesAsync();
        }

        public async Task RemoveDocumentFromActionRequired(int documentId, int companyId, int employeeId)
        {
            var actionRequiredIds = await _dbContext.ActionRequiredDocuments
                .Where(x =>
                    x.DocumentId == documentId
                    && x.EmployeeId == employeeId)
                .ToListAsync();

            _dbContext.ActionRequiredDocuments.RemoveRange(actionRequiredIds);
            await _dbContext.SaveChangesAsync();
        }
    }
}
