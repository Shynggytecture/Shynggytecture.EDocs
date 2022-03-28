using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class DocumentRouteCompanyEmployee
    {
        public int Id { get; set; }

        public int? DocumentRouteCompanyId { get; set; }
        public virtual DocumentRouteCompany DocumentRouteCompany { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int OrderNumber { get; set; }

        public bool? State { get; set; }
    }
}
