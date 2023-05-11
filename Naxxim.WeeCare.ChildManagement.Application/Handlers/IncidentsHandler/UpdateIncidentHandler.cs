using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler
{
    public class UpdateIncidentHandler : IRequestHandler<UpdateIncidentCommand, ChildIncidentDetails>
    {
        private readonly IincidentRepository _incidentRepository;

        public UpdateIncidentHandler(IincidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public async Task<ChildIncidentDetails> Handle(UpdateIncidentCommand request, CancellationToken cancellationToken)
        {
            var IncidentDetails = _incidentRepository.GetIncidentById(request.HealthId);

            if (IncidentDetails != null)
            {
                IncidentDetails.DurationOfTheIncident = request.DurationOfTheIncident;
                IncidentDetails.TypeOfIncident = request.TypeOfIncident;
                IncidentDetails.ChildStatus = request.ChildStatus;
                IncidentDetails.ActionsPrises = request.ActionsPrises;



                _incidentRepository.UpdateIncident(IncidentDetails);
            }

            return IncidentDetails;
        }
    }
}
