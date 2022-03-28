using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class DocumentRouteCompany
    {
        public int Id { get; set; }

        public int? DocumentRouteId { get; set; }
        public virtual DocumentRoute DocumentRoute { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public bool? State { get; set; }

        public virtual ICollection<DocumentRouteCompanyEmployee> DocumentRouteCompanyEmployees { get; set; }
    }
}
