using MediatR;
using Microsoft.AspNetCore.Mvc;
using Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Handlers;
using Naxxim.WeeCare.ChildManagement.Application.Queries;
using Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;

namespace Naxxim.WeeCare.ChildManagement.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ChildController> _logger;
        public ChildController(IMediator mediator, ILogger<ChildController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost("createchild")]
        public async Task<Result> CreateChild(CreateChildCommand childDto)
        {
            
                return await _mediator.Send(childDto);
              
        }
        [HttpGet("GetChildByParentId")]
        public async Task<List<Child>> Get(int parentid)
        {
            return await _mediator.Send(new GetChildByParentIdQuery { parentId = parentid });
        }
        [HttpGet("AllChildren")]
        public async Task<List<Child>> Getchildren()
        {
            return await _mediator.Send(new GetChildren());
        }
        [HttpPut("UpdateChild")]
        public async Task<ActionResult<Child>> updatechild(UpdateChildCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("deletechild")]
        public async Task<bool> DeleteUser(int Childid)
        {
            return await _mediator.Send(new DeleteChildCommand() { ChildId = Childid });
        }
        [HttpGet("GetChildsId")]
        public async Task<List<string>> GetUniqueCode()
        {
            return await _mediator.Send(new GetAllChildrenId());
        }
    }
}
