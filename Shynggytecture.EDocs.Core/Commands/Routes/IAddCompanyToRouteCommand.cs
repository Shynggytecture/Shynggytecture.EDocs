using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Routes
{
    public interface IAddCompanyToRouteCommand : ICommandAsync<AddCompanyToRouteCommandArg, string>
    {
    }

    public class AddCompanyToRouteCommandArg 
    {
        public int DocumentId { get; set; }

        public int CompanyId { get; set; }

        public bool IsSender { get; set; }
    }
}
