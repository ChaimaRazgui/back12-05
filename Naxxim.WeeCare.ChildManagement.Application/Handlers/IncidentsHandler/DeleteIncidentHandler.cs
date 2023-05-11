using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler
{
    public class DeleteIncidentHandler : IRequestHandler<DeleteIncidentCommand, bool>
    {
        private readonly IincidentRepository _incidentRepository;

        public DeleteIncidentHandler(IincidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        public Task<bool> Handle(DeleteIncidentCommand request, CancellationToken cancellationToken)
        {
            var IncidentDetails = _incidentRepository.GetIncidentById(request.HealthId);
            return Task.FromResult(_incidentRepository.Deleteincident(IncidentDetails.HealthId));
        }
    }
}
