using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Workflows.Documents
{
    public class DocumentWorkflowData
    {
        public int CompanyId { get; set; }
        public int OwnerEmployeeId { get; set; }

        public bool EmployeeCanCreateDocument { get; set; }

        public string DocumentName { get; set; }

        public string DocumentContent { get; set; }

        public string DocumentPublicInfo { get; set; }

        public string DocumentPrivateInfo { get; set; }

        public int DocumentId { get; set; }

        public string DocumentPath { get; set; }

        public DocumentWorkflowData()
        {
        }

        public DocumentWorkflowData(
            int companyId,
            int ownerEmployeeId,
            string documentName,
            string documentContent,
            string documentPublicInfo,
            string documentPrivateInfo)
        {
            this.CompanyId = companyId;
            this.OwnerEmployeeId = ownerEmployeeId;
            this.DocumentName = documentName;
            this.DocumentContent = documentContent;
            this.DocumentPublicInfo = documentPublicInfo;
            this.DocumentPrivateInfo = documentPrivateInfo;
        }

    }
}
