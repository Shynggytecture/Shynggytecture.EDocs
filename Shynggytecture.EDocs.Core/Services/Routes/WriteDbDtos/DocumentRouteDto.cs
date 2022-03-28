using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Routes.WriteDbDtos
{
    public class DocumentRouteDto
    {
        public int CompanySenderId { get; set; }

        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPublicInfo { get; set; }

        public int CompanyId { get; set; }

        public List<int> EmployeeIds { get; set; }
    }
}
