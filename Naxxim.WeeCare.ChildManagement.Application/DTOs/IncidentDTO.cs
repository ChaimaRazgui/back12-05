using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.DTOs
{
    public class IncidentDTO
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? TypeOfIncident { get; set; }
        public string? DurationOfTheIncident { get; set; }
        public string? ChildStatus { get; set; }
        public string? ActionsPrises { get; set; }

    }
}
