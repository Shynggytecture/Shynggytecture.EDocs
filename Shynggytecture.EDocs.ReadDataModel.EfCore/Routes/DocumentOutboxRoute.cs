using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Routes
{
    public class DocumentOutboxRoute
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string DocumentName { get; set; }
        public DateTime DocumentCreatedOn { get; set; }
        public string DocumentPublicInformation { get; set; }

        public int CompanyId { get; set; }

        public string CompanyCreatorCompanyName { get; set; }

        public string CompanyCreatorCompanyPublicNumber { get; set; }

        public bool IsDeleted { get; set; }
    }
}
