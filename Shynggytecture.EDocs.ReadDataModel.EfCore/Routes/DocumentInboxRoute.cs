using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Routes
{
    public class DocumentInboxRoute
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }

        public string EmployeePosition { get; set; }

        public int DocumentId { get; set; }

        public int CompanyId { get; set; }

        public int SenderCompanyId { get; set; }

        public string DocumentName { get; set; }
        public DateTime DocumentCreatedOn { get; set; }
        public string DocumentPublicInformation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
