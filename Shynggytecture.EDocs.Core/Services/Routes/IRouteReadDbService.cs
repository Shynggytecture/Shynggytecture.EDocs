using Shynggytecture.EDocs.Core.Services.Routes.ReadDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Routes
{
    public interface IRouteReadDbService
    {
        Task AddDocumentToActionRequired(AddDocumentActionRequiredDto item);

        Task RemoveDocumentFromActionRequired(int documentId, int companyId, int employeeId);

        Task AddEmployeeToHandleRouteList(int documentId, int companyId, int employeeId, int senderCompanyId);
    }
}
