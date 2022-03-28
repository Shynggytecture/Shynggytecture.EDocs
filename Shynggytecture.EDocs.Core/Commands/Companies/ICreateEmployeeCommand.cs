using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Companies
{
    public interface ICreateEmployeeCommand : ICommandAsync<CreateCompanyCommandArg, string>
    {
    }

    public class CreateEmployeeCommandArg 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string PrivateInformation { get; set; }

        public bool IsHead { get; set; }
    }
}
