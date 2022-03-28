using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Companies
{
    public interface IAssignPermissionToEmployeeCommand : ICommandAsync<AssignPermissionToEmployeeCommandArg, string>
    {
    }

    public class AssignPermissionToEmployeeCommandArg 
    {
        public int CompanyId { get; set; }

        public int EmployeeId { get; set; }
    }
}
