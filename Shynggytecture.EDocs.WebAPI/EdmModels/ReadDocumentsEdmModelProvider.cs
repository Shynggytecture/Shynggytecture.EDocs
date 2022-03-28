using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.EdmModels
{
    public static class ReadDocumentsEdmModelProvider
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<InboxDocument>("InboxDocuments");
            builder.EntitySet<OutboxDocument>("OutboxDocuments");
            builder.EntitySet<OutboxDocumentReceiver>("OutboxDocumentReceivers");
            builder.EntitySet<OwnedDocument>("OwnedDocuments");

            EdmModel model = builder.GetEdmModel() as EdmModel;

            return model;
        }
    }
}
