using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.DTOs
{
    public class JournalDTO
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? ArrivalTime { get; set; }
        public string? DepartureTime { get; set; }
        public string? LastModified { get; set; }
        public string? NapStart { get; set; }
        public string? NapEnd { get; set; }
        public bool repasMatin { get; set; }
        public bool repasMidi { get; set; }
        public bool Medication { get; set; }
    }
}
