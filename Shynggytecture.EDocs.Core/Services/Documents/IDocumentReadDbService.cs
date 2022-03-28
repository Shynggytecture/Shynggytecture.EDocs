using Shynggytecture.EDocs.Core.Services.Documents.ReadDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Documents
{
    public interface IDocumentReadDbService
    {
        Task<int> CreateOwnedDocument(CreateOwnedDbDto item);

        Task<bool> CheckDocumentExist(int documentId);

        Task DeleteDocument(int documentId);

        Task AddDocumentToInbox(int documentId, string documentName, string documentPublicInfo, int companyId, int employeeId, int senderCompanyId);
        Task AddDocumentToOutbox(int documentId, string documentName, string documentPublicInfo, int companyId, int employeeId, List<int> receiverCompanyIds);
    }
}
