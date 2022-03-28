using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Documents
{
    public interface IDocumentWriteDbService
    {
        Task<bool> CheckEmployeeCanCreateDocument(int id);

        Task<string> SaveDocumentContentAsBlob(int documentId, string content);

        Task<int> CreateDocument(string name, int ownerId, string publicInfo, string privateInfo);

        Task UpdateDocumentPath(int documentId, string path);

        Task<bool> CheckDocumentExist(int documentId);

        Task DeleteDocument(int documentId);
    }
}
