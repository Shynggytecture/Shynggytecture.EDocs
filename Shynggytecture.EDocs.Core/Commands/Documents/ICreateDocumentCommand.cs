using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Documents
{
    public interface ICreateDocumentCommand : ICommandAsync<CreateDocumentCommandArg, string>
    {
    }

    public class CreateDocumentCommandArg 
    {
        public string Name { get; set; }

        public int EmployeeOwnerId { get; set; }

        public int CompanyId { get; set; }

        public string PublicInformation { get; set; }

        public string Content { get; set; }

        public string PrivateInformation { get; set; }
    }
}
