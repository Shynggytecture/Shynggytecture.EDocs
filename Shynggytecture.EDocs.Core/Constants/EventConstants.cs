using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Constants
{
    public static class EventConstants
    {
        public static string AddSenderEmployeeToCompanyRouteEvent { get; private set; } = "AddSenderEmployeeToCompanyRouteEvent";
        public static string AddReceiverCompanyToRouteEvent { get; private set; } = "AddReceiverCompanyToRouteEvent";
        public static string StartSenderRouteEvent { get; private set; } = "StartSenderRouteEvent";
        public static string AcceptSenderCompanyRouteByEmployeeEvent { get; private set; } = "AcceptSenderCompanyRouteByEmployeeEvent";
        public static string AddReceiverEmployeeToCompanyRouteEvent { get; private set; } = "AddReceiverEmployeeToCompanyRouteEvent";
        public static string StartReceiverRouteEvent { get; private set; } = "StartReceiverRouteEvent";
        public static string AcceptReceiverCompanyRouteByEmployee { get; private set; } = "AcceptReceiverCompanyRouteByEmployee";

    }
}
