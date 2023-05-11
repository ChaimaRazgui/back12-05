using MediatR;
using Microsoft.Extensions.Logging;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler
{
    public class CreateIncideentHandler : IRequestHandler<CreateIncidentCommand, Result>
    {
        private readonly IincidentRepository _incidentRepository;
        private readonly IChildRepository _childRepository;
        private readonly ILogger<CreateIncideentHandler> _logger;
        public CreateIncideentHandler(IincidentRepository incidentRepository, IChildRepository childRepository, ILogger<CreateIncideentHandler> logger)
        {
            _incidentRepository = incidentRepository;
            _childRepository = childRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            var child = _childRepository.GetChildByUniqueId(request.UniqueCode);
            var IncidentDetails = new ChildIncidentDetails
            {
                HealthId = request.HealthId,
                TypeOfIncident = request.TypeOfIncident,
                DurationOfTheIncident = request.DurationOfTheIncident,
                ChildStatus = request.ChildStatus,
                ActionsPrises = request.ActionsPrises,
                IdChild = child.ChildId
            };

            await _incidentRepository.CreateIncident(IncidentDetails);

            return new Result { StatusCode = 200, Message = "Incident created successfully." };
            }

          
      
    }
}
