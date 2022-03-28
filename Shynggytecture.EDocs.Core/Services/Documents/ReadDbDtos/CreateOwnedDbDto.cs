using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Services.Documents.ReadDbDtos
{
    public class CreateOwnedDbDto
    {
        public int DocumentId { get; set; }

        public int CompanyId { get; set; }

        public int OwnerEmployeeId { get; set; }

        public string Name { get; set; }

        public string PublicInformation { get; set; }

        public string PrivateInformation { get; set; }

        public string Path { get; set; }
    }
}
