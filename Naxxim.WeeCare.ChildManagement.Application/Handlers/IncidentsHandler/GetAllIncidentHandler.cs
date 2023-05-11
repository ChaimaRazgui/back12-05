using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries;
using Naxxim.WeeCare.ChildManagement.Application.Queries.IncidentsQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler
{
    public class GetAllIncidentHandler : IRequestHandler<GetAllIncidentsQuery, List<ChildwithUniquecodeIncident>>
    {
        private readonly IincidentRepository _incidentRepository;
        private readonly IChildRepository _childRepository;
        public GetAllIncidentHandler(IincidentRepository incidentRepository, IChildRepository childRepository)
        {
            _incidentRepository = incidentRepository;
            _childRepository = childRepository;
        }
        public async Task<List<ChildwithUniquecodeIncident>> Handle(GetAllIncidentsQuery request, CancellationToken cancellationToken)
        {
            var Listeincidents = new List<ChildwithUniquecodeIncident>();
            var incidents = _incidentRepository.GetAllIncidents();
            foreach (var incident in incidents)
            {
                var child = _childRepository.GetChildById(incident.IdChild); 
                if (child != null)
                {
                    var newIncident = new ChildwithUniquecodeIncident
                    {
                        healthId = incident.HealthId,
                        UniqueCode = child.UniqueCode,
                        TypeOfIncident = incident.TypeOfIncident,
                        DurationOfTheIncident = incident.DurationOfTheIncident,
                        ChildStatus = incident.ChildStatus,
                        ActionsPrises = incident.ActionsPrises


                    };
                    Listeincidents.Add(newIncident);
                }
                 
            }
            return Listeincidents;
        }
    }
}

