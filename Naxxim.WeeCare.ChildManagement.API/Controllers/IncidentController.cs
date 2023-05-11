using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries;
using Naxxim.WeeCare.ChildManagement.Application.Queries.IncidentsQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;

namespace Naxxim.WeeCare.ChildManagement.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class IncidentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IChildRepository _childRepository;
        private readonly IincidentRepository _incidentRepository;
        public IncidentController(IMediator mediator, IChildRepository childRepository, IincidentRepository incidentRepository)
        {
            _mediator = mediator;
            _childRepository = childRepository;
            _incidentRepository = incidentRepository;
        }
        [HttpGet("AllIncident")]
        public async Task<List<ChildwithUniquecodeIncident>> Getchildren()
        {
            return await _mediator.Send(new GetAllIncidentsQuery());
        }
        [HttpPost("createIncident")]
        public async Task<Result> CreateIncident(CreateIncidentCommand IncidentDto)
        {

            return await _mediator.Send(IncidentDto);

        }
        [HttpPut("UpdateIncident")]
        public async Task<ActionResult<ChildIncidentDetails>> updatechild(UpdateIncidentCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("deleteIncident")]
        public async Task<bool> DeleteUser(int healthid)
        {
            return await _mediator.Send(new DeleteIncidentCommand() { HealthId = healthid });
        }
        [HttpGet("ParentChildIncident")]
        public IActionResult GetIncidentsByParentId(int parentId)
        {
            var childs = _childRepository.GetChildbyParentId(parentId);
            if (childs.Count == 0)
            {
                return NotFound();
            }

            var incidents = new List<IncidentDTO>();
            foreach (var child in childs)
            {
                var childIncidents = _incidentRepository.GetIncidentsByChildId(child.ChildId);
                if (childIncidents is not null )
                {
                    foreach (var incident in childIncidents)
                    {
                        var incidentDTO = new IncidentDTO
                        {
                            LastName = child.LastName,
                            FirstName = child.FirstName,
                            TypeOfIncident = incident.TypeOfIncident,
                            DurationOfTheIncident = incident.DurationOfTheIncident,
                            ChildStatus = incident.ChildStatus,
                            ActionsPrises = incident.ActionsPrises
                        };

                        incidents.Add(incidentDTO);
                    }
                }
            }

            return Ok(incidents);
        }
    }
}
