using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class EDocsCommandContext : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }
        
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeePermission> EmployeePermissions { get; set; }

        public virtual DbSet<Document> Documents { get; set; }
        
        public virtual DbSet<DocumentRoute> DocumentRoutes { get; set; }
        
        public virtual DbSet<DocumentRouteCompany> DocumentRouteCompanies { get; set; }

        public virtual DbSet<DocumentRouteCompanyEmployee> DocumentRouteCompanyEmployees { get; set; }

        public EDocsCommandContext()
        {
            this.Database.EnsureCreated();
        }

        public EDocsCommandContext(DbContextOptions<EDocsCommandContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
