using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Routes
{
    public class RoutesDbContext : DbContext
    {
        public virtual DbSet<ActionRequiredDocument> ActionRequiredDocuments { get; set; }

        public virtual DbSet<DocumentOutboxRoute> DocumentOutboxRoutes { get; set; }

        public virtual DbSet<DocumentInboxRoute> DocumentInboxRoutes { get; set; }

        public RoutesDbContext()
        {
            this.Database.EnsureCreated();
        }

        public RoutesDbContext(DbContextOptions<RoutesDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

    }
}
