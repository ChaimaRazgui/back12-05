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
    public class ChildJournal
    {
        [Key]
        public int JournalId { get; set; }
        public string ArrivalTime { get; set; }
        public string? DepartureTime { get; set; }

        public DateTime LastModified { get; set; }
        public string? NapStart { get; set; }
        public string? NapEnd { get; set; }
        public bool repasMatin { get; set; }
        public bool repasMidi { get; set; }
        public bool Medication { get; set; }
        public int IdChild { get; set; }
        [JsonIgnore]
        public virtual Child? child { get; set; }
    }
}
