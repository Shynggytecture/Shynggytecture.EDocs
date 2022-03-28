using Microsoft.EntityFrameworkCore;
using Shynggytecture.EDocs.Core.Services.Documents;
using Shynggytecture.EDocs.Core.Services.Documents.ReadDbDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore.Services
{
    public class DocumentWriteDbService : IDocumentWriteDbService
    {
        private readonly EDocsCommandContext _dbContext;

        public DocumentWriteDbService(EDocsCommandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckDocumentExist(int documentId)
        {
            var docs = await _dbContext.Documents
                .Where(x => x.Id == documentId)
                .ToListAsync();

            return docs.Any();
        }

        public async Task<bool> CheckEmployeeCanCreateDocument(int id)
        {
            var empl = await _dbContext.Employees
                .Where(x => x.Id == id && x.IsHead == true)
                .ToListAsync();

            return empl.Any();
        }

        public async Task<int> CreateDocument(string name, int ownerId, string publicInfo, string privateInfo)
        {
            var nDoc = new Document()
            {
                Name = name,
                OwnerId = ownerId,
                PublicInformation = publicInfo,
                PrivateInformation = privateInfo,
                Status = DocumentStatusEnum.New
            };

            _dbContext.Documents
                .Add(nDoc);

            await _dbContext.SaveChangesAsync();

            return nDoc.Id;
        }

        public async Task DeleteDocument(int documentId)
        {
            var routeEmployees = await _dbContext.DocumentRouteCompanyEmployees
                .Where(x => x.DocumentRouteCompany.DocumentRouteId == documentId)
                .ToListAsync();

            var routeCompanies = await _dbContext.DocumentRouteCompanies
                .Where(x => x.DocumentRouteId == documentId)
                .ToListAsync();

            var route = await _dbContext.DocumentRoutes
                .FirstOrDefaultAsync(x => x.Id == documentId);

            var doc = await _dbContext.Documents
                .FirstAsync(x => x.Id == documentId);

            _dbContext.DocumentRouteCompanyEmployees.RemoveRange(routeEmployees);
            _dbContext.DocumentRouteCompanies.RemoveRange(routeCompanies);

            if (route != null)
            {
                _dbContext.DocumentRoutes.Remove(route);
            }

            _dbContext.Documents.Remove(doc);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> SaveDocumentContentAsBlob(int documentId, string content)
        {
            var doc = await _dbContext.Documents
                .FirstAsync(x => x.Id == documentId);

            return $"blobs/{documentId}";
        }

        public async Task UpdateDocumentPath(int documentId, string path)
        {
            var doc = await _dbContext.Documents
                .FirstAsync(x => x.Id == documentId);
        }
    }
}
