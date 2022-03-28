using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Documents.WriteDbDtos
{
    public class CreateDocumentDto
    {
        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public string PublicInfo { get; set; }

        public string PrivateInfo { get; set; }
    }
}
