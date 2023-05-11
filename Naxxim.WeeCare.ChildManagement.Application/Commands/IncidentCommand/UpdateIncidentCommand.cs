using MediatR;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand
{
    public class UpdateIncidentCommand :IRequest <ChildIncidentDetails>
    {
        public int HealthId { get; set; }
        public string? TypeOfIncident { get; set; }
        public string? DurationOfTheIncident { get; set; }
        public string? ChildStatus { get; set; }
        public string? ActionsPrises { get; set; }
    }
}
