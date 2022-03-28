using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Shynggytecture.EDocs.Workflows.Routes.Steps
{
    public class PrepareRouteStep : StepBody
    {
        public int In_CompanyId { get; set; }

        public List<int> In_InternalRouteIds { get; set; }

        public List<int> In_ExternalRouteIds { get; set; }

        public List<CompanyRouteModel> Out_Route { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            this.Out_Route = new List<CompanyRouteModel>();
            this.Out_Route.Add(new CompanyRouteModel()
            {
                CompanyId = this.In_CompanyId,
            });

            this.Out_Route.AddRange(
                this.In_ExternalRouteIds.Select(x => new CompanyRouteModel() 
                {
                    CompanyId = x,
                }).ToList());

            return ExecutionResult.Next();
        }
    }
}
