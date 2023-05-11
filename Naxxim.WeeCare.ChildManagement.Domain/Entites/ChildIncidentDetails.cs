using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Domain.Entites
{
    public class ChildIncidentDetails
    {
        [Key]
        public int HealthId { get; set; }   
        public string? TypeOfIncident { get; set; }
        public string? DurationOfTheIncident { get; set; }
        public string? ChildStatus { get; set; }
        public string? ActionsPrises { get; set; }
        public int IdChild { get; set; }
        [JsonIgnore]
        public virtual Child? child { get; set; }
    }
}
