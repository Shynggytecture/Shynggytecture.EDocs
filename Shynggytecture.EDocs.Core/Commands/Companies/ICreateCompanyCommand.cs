using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Companies
{
    public interface ICreateCompanyCommand : ICommandAsync<CreateCompanyCommandArg, string>
    {
    }

    public class CreateCompanyCommandArg 
    {
        public string Name { get; set; }

        public string PublicNumber { get; set; }

        public string PrivateInformation { get; set; }
    }
}
