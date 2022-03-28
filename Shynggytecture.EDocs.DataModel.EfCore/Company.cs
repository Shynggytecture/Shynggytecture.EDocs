using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class Company
    {
        public int Id { get; set; }
        public string PublicNumber { get; set; }
        public string Name { get; set; }
        public string PrivateInformation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<DocumentRouteCompany> DocumentRouteCompanies { get; set; }
    }
}
