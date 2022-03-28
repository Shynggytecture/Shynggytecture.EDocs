using Shynggytecture.EDocs.Core.Services.Routes.WriteDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Routes
{
    public interface IRouteWriteDbService
    {
        Task<int> CreateRoute(CreateRouteDto item);

        Task AddEmployeeToCompanyRoute(AddEmployeeToCompanyRouteDto item);

        Task AddCompanyToRoute(AddCompanyToRoute item);

        Task StartRoute(int documentId);

        Task StartCompanyRoute(int documentId, int companyId);

        Task AcceptRouteByEmployee(int documentId, int companyId, int employeeId);

        Task<GetDocumentDto> GetDocument(int documentId);

        Task<List<int>> GetCompanyHeadEmployeeIds(int companyId);

        Task<List<int>> GetAllEmployeesFromDocument(int id);

        Task<List<DocumentRouteDto>> GetDocumentRoutes(int documentId);
    }
}
