using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Shynggytecture.EDocs.DataModel.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.EdmModels
{
    public static class WriteEdmModelProvider
    {
        public static IEdmModel GetEdmModel() 
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<EmployeePermission>("EmployeePermissions");
            builder.EntitySet<Document>("Documents");
            builder.EntitySet<DocumentRoute>("DocumentRoutes");
            builder.EntitySet<DocumentRouteCompany>("DocumentRouteCompanies");
            builder.EntitySet<DocumentRouteCompanyEmployee>("DocumentRouteCompanyEmployees");

            EdmModel model = builder.GetEdmModel() as EdmModel;

            return model;
        }
    }
}
