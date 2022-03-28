using Microsoft.AspNetCore.Mvc;
using Shynggytecture.EDocs.Core.Commands.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly ICreateDocumentCommand _command;

        public DocumentsController(ICreateDocumentCommand command)
        {
            _command = command;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDocumentCommandArg model)
        {
            var res = await _command.Handle(model);

            return Ok(res);
        }
    }
}
