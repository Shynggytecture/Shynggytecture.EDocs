﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands.Routes
{
    public interface IRejectRouteCommand : ICommandAsync<RejectRouteArg, string>
    {
    }

    public class RejectRouteArg 
    {
        public int DocumentId { get; set; }

        public int EmployeeId { get; set; }

        public int CompanyId { get; set; }
    }
}
