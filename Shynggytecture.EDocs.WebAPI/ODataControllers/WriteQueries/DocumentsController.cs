using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Shynggytecture.EDocs.DataModel.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.ODataControllers.WriteQueries
{
    [ApiController]
    [Route("odata/write/[controller]")]
    public class DocumentsController : BaseODataController<Document>
    {
        private readonly EDocsCommandContext _context;

        public DocumentsController(EDocsCommandContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
