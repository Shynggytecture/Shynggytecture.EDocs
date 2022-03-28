using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Routes
{
    public interface IRejectCompanyRouteCommand : ICommandAsync<RejectCompanyRouteCommandArg, string>
    {
    }

    public class RejectCompanyRouteCommandArg
    {
        public int DocumentId { get; set; }

        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }
    }
}
