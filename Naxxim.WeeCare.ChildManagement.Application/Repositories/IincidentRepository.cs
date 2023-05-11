using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Repositories
{
    public interface IincidentRepository
    {
       Task<ChildIncidentDetails> CreateIncident(ChildIncidentDetails incident);
        List<ChildIncidentDetails> GetAllIncidents();
        bool Deleteincident(int Id);
        ChildIncidentDetails UpdateIncident(ChildIncidentDetails incident);

        ChildIncidentDetails GetIncidentById(int Id);
        List<ChildIncidentDetails> GetIncidentsByChildId(int childId);

    }
}
