using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Workflows.Routes
{
    public class RouteWorkflowData
    {
        public int DocumentId { get; set; }

        public int OwnerEmployeeId { get; set; }

        public int SenderCompanyId { get; set; }

        public bool IsRouteReady { get; set; }

        public int AddedToSenderInternalRouteLastEmployeeId { get; set; }

        public int AddedToSenderExternalRouteLastCompanyId { get; set; }

        public int LastAccepterEmployeeId { get; set; }

        public int LastAddedToReceiverRouteEmployeeId { get; set; }

        public List<int> CurrentInternalRoute { get; set; }

        public List<int> CurrentExternalRoute { get; set; }

        public List<int> CurrentCompanyHeads { get; set; }

        public CompanyRouteModel CurrentCompanyRoute { get; set; }

        public List<CompanyRouteModel> RouteCompanies { get; set; }

        public string DocumentName { get; set; }

        public string DocumentPublicInfo { get; set; }

        public RouteWorkflowData()
        {
        }

        public RouteWorkflowData(
            int documentId,
            int ownerEmployeeId,
            int senderCompanyId)
        {
            this.DocumentId = documentId;
            this.OwnerEmployeeId = ownerEmployeeId;
            this.SenderCompanyId = senderCompanyId;
        }

        public List<CompanyRouteModel> GetReceivers() 
        {
            return this.RouteCompanies
                .Where(x => x.CompanyId != this.SenderCompanyId)
                .ToList();
        }
    }

    public class CompanyRouteModel 
    {
        public int CompanyId { get; set; }

        public bool IsCompleted { get; set; }
    }

    public class CompanyEmployeeRoute 
    {
        public int EmployeeId { get; set; }
    }
}
