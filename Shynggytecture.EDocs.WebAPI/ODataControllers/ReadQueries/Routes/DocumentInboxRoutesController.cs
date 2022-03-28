using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Shynggytecture.EDocs.ReadDataModel.EfCore.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.ODataControllers.ReadQueries.Routes
{
    [ApiController]
    [Route("odata/read/routes/[controller]")]
    public class DocumentInboxRoutesController : BaseODataController<DocumentInboxRoute>
    {
        private readonly RoutesDbContext _context;

        public DocumentInboxRoutesController(RoutesDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
