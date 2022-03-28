using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Routes
{
    public interface ICreateDocumentRouteCommand : ICommandAsync<CreateDocumentRouteArg, string>
    {
    }

    public class CreateDocumentRouteArg 
    {
        public int DocumentId { get; set; }

        public int OwnerEmployeeId { get; set; }

        public int SenderCompanyId { get; set; }
    }
}
