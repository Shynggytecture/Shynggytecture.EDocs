using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Routes.ReadDbDtos
{
    public class AddDocumentActionRequiredDto
    {
        public int DocumentId { get; set; }

        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }

        public DocumentDto Document { get; set; }
    }
}
