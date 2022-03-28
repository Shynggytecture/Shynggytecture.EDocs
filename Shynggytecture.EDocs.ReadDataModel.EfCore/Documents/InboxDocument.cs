using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Documents
{
    public class InboxDocument
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public int EmployeeId { get; set; }

        public string DocumentName { get; set; }
        public DateTime DocumentCreatedOn { get; set; }
        public string DocumentPublicInformation { get; set; }

        public int CreatorCompanyId { get; set; }

        public string CreatorCompanyName { get; set; }

        public string CreatorCompanyPublicNumber { get; set; }

        public int TargetCompanyId { get; set; }

        public DateTime CreatedBy { get; set; }
    }
}
