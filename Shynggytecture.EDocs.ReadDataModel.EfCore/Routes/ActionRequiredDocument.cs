using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Routes
{
    public class ActionRequiredDocument
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int DocumentId { get; set; }

        public string DocumentName { get; set; }
        public DateTime DocumentCreatedOn { get; set; }
        public string DocumentPublicInformation { get; set; }

        public int SenderCompanyId { get; set; }

        public bool IsHandled { get; set; }
    }
}
