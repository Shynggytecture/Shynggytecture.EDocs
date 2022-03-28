using Microsoft.AspNetCore.Mvc;
using Shynggytecture.EDocs.Core.Commands.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly IAcceptDocumentCommand _acceptDocumentCommand;
        private readonly IAddCompanyToRouteCommand _addCompanyToRouteCommand;
        private readonly IAddEmployeeToCompanyRouteCommand _addEmployeeToCompanyRouteCommand;
        private readonly ICreateDocumentRouteCommand _createDocumentRouteCommand;
        private readonly IStartCompanyRouteCommand _startCompanyRouteCommand;

        public RoutesController(
            IAcceptDocumentCommand acceptDocumentCommand,
            IAddCompanyToRouteCommand addCompanyToRouteCommand,
            IAddEmployeeToCompanyRouteCommand addEmployeeToCompanyRouteCommand,
            ICreateDocumentRouteCommand createDocumentRouteCommand,
            IStartCompanyRouteCommand startCompanyRouteCommand)
        {
            _acceptDocumentCommand = acceptDocumentCommand;
            _addCompanyToRouteCommand = addCompanyToRouteCommand;
            _addEmployeeToCompanyRouteCommand = addEmployeeToCompanyRouteCommand;
            _createDocumentRouteCommand = createDocumentRouteCommand;
            _startCompanyRouteCommand = startCompanyRouteCommand;
        }

        [HttpPut("Accept")]
        public async Task<IActionResult> PostAcceptDocument([FromBody] AcceptDocumentCommandArg model)
        {
            var res = await _acceptDocumentCommand.Handle(model);
            return Ok(res);
        }

        [HttpPost("Company")]
        public async Task<IActionResult> PostAddCompanyToRouteCommand([FromBody] AddCompanyToRouteCommandArg model)
        {
            var res = await _addCompanyToRouteCommand.Handle(model);
            return Ok(res);
        }

        [HttpPost("Company/Employee")]
        public async Task<IActionResult> PostAddEmployeeToCompanyRouteCommand([FromBody] AddEmployeeToCompanyRouteCommandArg model)
        {
            var res = await _addEmployeeToCompanyRouteCommand.Handle(model);
            return Ok(res);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostCreateDocumentRouteCommand([FromBody] CreateDocumentRouteArg model)
        {
            var res = await _createDocumentRouteCommand.Handle(model);
            return Ok(res);
        }

        [HttpPut("Start")]
        public async Task<IActionResult> PostStartCompanyRouteCommand([FromBody] StartCompanyRouteArg model)
        {
            var res = await _startCompanyRouteCommand.Handle(model);
            return Ok(res);
        }
    }
}
