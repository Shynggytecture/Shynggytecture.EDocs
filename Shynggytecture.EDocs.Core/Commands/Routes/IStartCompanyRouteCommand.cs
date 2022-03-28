using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Routes
{
    public interface IStartCompanyRouteCommand : ICommandAsync<StartCompanyRouteArg, string>
    {
    }

    public class StartCompanyRouteArg 
    {
        public int DocumentId { get; set; }

        public int? CompanyId { get; set; }

        public int EmployeeId { get; set; }
    }
}
