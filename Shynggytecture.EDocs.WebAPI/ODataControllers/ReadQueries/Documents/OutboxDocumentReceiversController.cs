using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.ODataControllers.ReadQueries.Documents
{
    [ApiController]
    [Route("odata/read/documents/[controller]")]
    public class OutboxDocumentReceiverDocumentController : BaseODataController<OutboxDocumentReceiver>
    {
        private readonly DocumentsDbContext _context;

        public OutboxDocumentReceiverDocumentController(DocumentsDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
