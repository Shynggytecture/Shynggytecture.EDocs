using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.ReadDataModel.EfCore.Documents
{
    public class OutboxDocumentReceiver
    {
        public int Id { get; set; }

        public int OutboxDocumentId { get; set; }
        public virtual OutboxDocument OutboxDocumentData { get; set; }

        public int CompanyId { get; set; }

        public string CompanyCreatorCompanyName { get; set; }

        public string CompanyCreatorCompanyPublicNumber { get; set; }
    }
}
