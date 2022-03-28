using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.EdmModels
{
    public static class ReadRouteEdmModelProvider
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ActionRequiredDocument>("ActionRequiredDocuments");
            builder.EntitySet<DocumentOutboxRoute>("DocumentOutboxRoutes");
            builder.EntitySet<DocumentInboxRoute>("DocumentInboxRoutes");

            EdmModel model = builder.GetEdmModel() as EdmModel;

            return model;
        }
    }
}
