using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Companies
{
    public class CompanyDbContext : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public CompanyDbContext()
        {
            this.Database.EnsureCreated();
        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        {
            this.Database.EnsureCreated();
        }
    }
}
