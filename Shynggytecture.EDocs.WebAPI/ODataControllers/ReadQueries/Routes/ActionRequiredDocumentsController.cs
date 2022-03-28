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
    public class ActionRequiredDocumentsController : BaseODataController<ActionRequiredDocument>
    {
        private readonly RoutesDbContext _context;

        public ActionRequiredDocumentsController(RoutesDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
