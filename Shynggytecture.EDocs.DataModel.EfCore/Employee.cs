using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string PrivateInformation { get; set; }

        public bool IsHead { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<EmployeePermission> EmployeePermissions { get; set; }

        public virtual ICollection<Document> OwnedDocument { get; set; }

        public virtual ICollection<DocumentRouteCompany> OwnedDocumentRoutes { get; set; }

        public virtual ICollection<DocumentRouteCompanyEmployee> DocumentRouteCompanyEmployees { get; set; }
    }
}
