using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Documents
{
    public class DocumentsDbContext : DbContext
    {
        public virtual DbSet<InboxDocument> InboxDocuments { get; set; }

        public virtual DbSet<OutboxDocument> OutboxDocuments { get; set; }

        public virtual DbSet<OutboxDocumentReceiver> OutboxDocumentReceivers { get; set; }

        public virtual DbSet<OwnedDocument> OwnedDocuments { get; set; }

        public DocumentsDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DocumentsDbContext(DbContextOptions<DocumentsDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
