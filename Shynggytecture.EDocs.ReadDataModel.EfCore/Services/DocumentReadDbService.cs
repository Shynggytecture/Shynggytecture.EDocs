using Microsoft.EntityFrameworkCore;
using Shynggytecture.EDocs.Core.Services.Documents;
using Shynggytecture.EDocs.Core.Services.Documents.ReadDbDtos;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Services
{
    public class DocumentReadDbService : IDocumentReadDbService
    {
        private readonly DocumentsDbContext _dbContext;

        public DocumentReadDbService(DocumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddDocumentToInbox(int documentId, string documentName, string documentPublicInfo, int companyId, int employeeId, int senderCompanyId)
        {
            var item = new InboxDocument() 
            {
                DocumentId = documentId,
                DocumentName = documentName,
                DocumentPublicInformation = documentPublicInfo,
                CreatorCompanyId = senderCompanyId,
                TargetCompanyId = companyId,
                EmployeeId = employeeId
            };

            _dbContext.InboxDocuments.Add(item);

            return _dbContext.SaveChangesAsync();
        }

        public Task AddDocumentToOutbox(int documentId, string documentName, string documentPublicInfo, int companyId, int employeeId, List<int> receiverCompanyIds)
        {
            var item = new OutboxDocument()
            {
                DocumentId = documentId,
                DocumentName = documentName,
                DocumentPublicInformation = documentPublicInfo,
                EmployeeId = employeeId,
                CreatorCompanyId = companyId,
                OutboxDocumentReceivers = receiverCompanyIds
                    .Select(x => new OutboxDocumentReceiver()
                    {
                        CompanyId = x
                    }).ToList()
            };

            _dbContext.OutboxDocuments.Add(item);

            return _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckDocumentExist(int documentId)
        {
            var inboxDocs = await _dbContext.InboxDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            var outboxDocs = await _dbContext.OutboxDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            var ownedDocs = await _dbContext.OwnedDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            return inboxDocs.Any() || outboxDocs.Any() || ownedDocs.Any();
        }

        public Task<int> CreateOwnedDocument(CreateOwnedDbDto item)
        {
            _dbContext.OwnedDocuments.Add(new OwnedDocument() 
            {
                DocumentId = item.DocumentId,
                CreatorCompanyId = item.CompanyId,
                OwnerEmployeeId = item.OwnerEmployeeId,
                DocumentCreatedOn = DateTime.Now,
                DocumentName = item.Name,
                DocumentPublicInformation = item.PublicInformation,
                CreatedBy = DateTime.Now
            });

            return _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDocument(int documentId)
        {
            var inboxDocs = await _dbContext.InboxDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            var outboxDocRecs = await _dbContext.OutboxDocumentReceivers
                .Where(x => x.OutboxDocumentData.DocumentId == documentId)
                .ToListAsync();

            var outboxDocs = await _dbContext.OutboxDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            var ownedDocs = await _dbContext.OwnedDocuments
                .Where(x => x.DocumentId == documentId)
                .ToListAsync();

            _dbContext.InboxDocuments.RemoveRange(inboxDocs);
            _dbContext.OutboxDocumentReceivers.RemoveRange(outboxDocRecs);
            _dbContext.OutboxDocuments.RemoveRange(outboxDocs);
            _dbContext.OwnedDocuments.RemoveRange(ownedDocs);

            await _dbContext.SaveChangesAsync();
        }
    }
}
