using Microsoft.EntityFrameworkCore;
using Shynggytecture.EDocs.Core.Services.Routes;
using Shynggytecture.EDocs.Core.Services.Routes.WriteDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore.Services
{
    public class RouteWriteDbService : IRouteWriteDbService
    {
        private readonly EDocsCommandContext _dbContext;

        public RouteWriteDbService(EDocsCommandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AcceptRouteByEmployee(int documentId, int companyId, int employeeId)
        {
            var emplRouteItem = await _dbContext.DocumentRouteCompanyEmployees
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == employeeId
                    && x.DocumentRouteCompany.CompanyId == companyId
                    && x.DocumentRouteCompany.DocumentRouteId == documentId);

            if (emplRouteItem == null) 
            {
                return;
            }

            emplRouteItem.State = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddCompanyToRoute(AddCompanyToRoute item)
        {
            var existingItem = await _dbContext.DocumentRouteCompanies
                .FirstOrDefaultAsync(x =>
                    x.DocumentRouteId == item.DocumentId
                    && x.CompanyId == item.CompanyId);

            if (existingItem != null)
                return;

            existingItem = new DocumentRouteCompany() 
            {
                DocumentRouteId = item.DocumentId,
                CompanyId = item.CompanyId
            };

            _dbContext.DocumentRouteCompanies.Add(existingItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddEmployeeToCompanyRoute(AddEmployeeToCompanyRouteDto item)
        {
            var existingItem = await _dbContext.DocumentRouteCompanyEmployees
                .FirstOrDefaultAsync(x =>
                    x.EmployeeId == item.EmployeeId
                    && x.DocumentRouteCompany.CompanyId == item.CompanyId
                    && x.DocumentRouteCompany.DocumentRouteId == item.DocumentId);

            if (existingItem != null)
                return;

            var companyRoute = await _dbContext.DocumentRouteCompanies
                .Include(x => x.DocumentRouteCompanyEmployees)
                .FirstOrDefaultAsync(x => 
                    x.CompanyId == item.CompanyId 
                    && x.DocumentRouteId == item.DocumentId);

            int order = 1;

            if (companyRoute == null)
            {
                companyRoute = new DocumentRouteCompany()
                {
                    CompanyId = item.CompanyId,
                    DocumentRouteId = item.DocumentId
                };

                _dbContext.DocumentRouteCompanies.Add(companyRoute);
                await _dbContext.SaveChangesAsync();
            }
            else 
            {
                order = companyRoute.DocumentRouteCompanyEmployees.Count + 1;
            }

            existingItem = new DocumentRouteCompanyEmployee() 
            {
                EmployeeId = item.EmployeeId,
                DocumentRouteCompanyId = companyRoute.Id,
                OrderNumber = order
            };

            _dbContext.DocumentRouteCompanyEmployees.Add(existingItem);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateRoute(CreateRouteDto item)
        {
            var existingItem = await _dbContext.DocumentRoutes
                .FirstOrDefaultAsync(x => x.Id == item.DocumentId);

            if (existingItem != null)
                return existingItem.Id;

            existingItem = new DocumentRoute() 
            {
                Id = item.DocumentId
            };

            _dbContext.DocumentRoutes.Add(existingItem);
            await _dbContext.SaveChangesAsync();

            return existingItem.Id;
        }

        public async Task<List<int>> GetAllEmployeesFromDocument(int id)
        {
            var data = await _dbContext.DocumentRouteCompanyEmployees
                .Where(x => x.DocumentRouteCompany.DocumentRouteId == id && x.EmployeeId != null)
                .Select(x => x.EmployeeId.Value)
                .ToListAsync();

            return data;
        }

        public async Task<List<int>> GetCompanyHeadEmployeeIds(int companyId)
        {
            var data = await _dbContext.Employees
                .Where(x => x.CompanyId == companyId && x.IsHead == true)
                .Select(x => x.Id)
                .ToListAsync();

            return data;
        }

        public async Task<GetDocumentDto> GetDocument(int documentId)
        {
            var item = await _dbContext.Documents
                .FirstAsync(x => x.Id == documentId);

            return new GetDocumentDto() 
            {
                Name = item.Name,
                PublicInfo = item.PublicInformation
            };
        }

        public async Task<List<DocumentRouteDto>> GetDocumentRoutes(int documentId)
        {
            var empls = await _dbContext.DocumentRouteCompanyEmployees
                .Where(x => x.DocumentRouteCompany.DocumentRouteId == documentId)
                .Select(x => new 
                {
                    EmployeeId = x.EmployeeId.Value,
                    CompanyId = x.DocumentRouteCompany.CompanyId.Value,
                    DocumentId = x.DocumentRouteCompany.DocumentRouteId.Value,
                    DocumentName = x.DocumentRouteCompany.DocumentRoute.Document.Name,
                    DocumentPublicInfo = x.DocumentRouteCompany.DocumentRoute.Document.PublicInformation,
                    SenderCompanyId = x.DocumentRouteCompany.DocumentRoute.Document.Owner.CompanyId.Value
                })
                .ToListAsync();

            var res = empls
                .GroupBy(x => new { x.CompanyId, x.SenderCompanyId, x.DocumentId, x.DocumentName, x.DocumentPublicInfo })
                .Select(x => new DocumentRouteDto() 
                {
                    CompanyId = x.Key.CompanyId,
                    CompanySenderId = x.Key.SenderCompanyId,
                    DocumentId = x.Key.DocumentId,
                    DocumentName = x.Key.DocumentName,
                    DocumentPublicInfo = x.Key.DocumentPublicInfo,
                    EmployeeIds = x
                        .Select(f => f.EmployeeId)
                        .ToList()
                }).ToList();

            return res;
        }

        public async Task StartCompanyRoute(int documentId, int companyId)
        {
            var item = await _dbContext.DocumentRouteCompanies
                .FirstOrDefaultAsync(x =>
                    x.CompanyId == companyId
                    && x.DocumentRouteId == documentId);

            if (item == null)
                return;

            item.State = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartRoute(int documentId)
        {
            var route = await _dbContext.DocumentRoutes
                .FirstOrDefaultAsync(x => x.Id == documentId);

            if (route == null)
                return;

            route.State = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
