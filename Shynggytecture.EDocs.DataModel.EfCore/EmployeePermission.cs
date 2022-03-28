using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.DataModel.EfCore
{
    public class EmployeePermission
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
