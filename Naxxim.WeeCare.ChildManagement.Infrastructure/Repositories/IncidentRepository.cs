using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Repositories
{
    public class IncidentRepository :IincidentRepository
    {
        private readonly ChildManagementDBContext _childManagementDBContext;
        public IncidentRepository(ChildManagementDBContext childManagementDBContext)
        {
            _childManagementDBContext = childManagementDBContext;
        }
        public List<ChildIncidentDetails> GetAllIncidents()
        {
            return _childManagementDBContext.ChildIncidentDetails.ToList();
        }
        public ChildIncidentDetails GetIncidentById(int Id)
        {
            return _childManagementDBContext.ChildIncidentDetails.Where(x => x.HealthId == Id).FirstOrDefault();
        }
        public List<ChildIncidentDetails> GetIncidentsByChildId(int childId)
        {
            return _childManagementDBContext.ChildIncidentDetails
                .Where(x => x.IdChild == childId)
                .ToList();
        }
        public async Task<ChildIncidentDetails> CreateIncident(ChildIncidentDetails incident)
        {
          
            _childManagementDBContext.ChildIncidentDetails.Add(incident);
           await _childManagementDBContext.SaveChangesAsync();

            return incident;
        }
        public ChildIncidentDetails UpdateIncident(ChildIncidentDetails incident)
        {
            var result = _childManagementDBContext.Update(incident);
            _childManagementDBContext.SaveChanges();
            return result.Entity;
        }
        public bool Deleteincident(int Id)
        {
            var filteredData = _childManagementDBContext.ChildIncidentDetails.Where(x => x.HealthId == Id).FirstOrDefault();
            var result = _childManagementDBContext.Remove(filteredData);
            _childManagementDBContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}
