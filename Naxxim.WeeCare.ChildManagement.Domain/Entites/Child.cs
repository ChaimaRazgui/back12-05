using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Domain.Entites
{
    public class Child
    {
        [Key]
        public int ChildId {get; set;}
        public string UniqueCode { get; set;}
        public string? LastName { get; set;}
        public string? FirstName { get; set;}
        public DateTime DateOfBirth { get; set;}
        public string? allergy { get; set;}
        public string? chronic_illness { get; set;}
        public int ParentId { get; set;}
        [JsonIgnore]
        public ICollection <ChildIncidentDetails> Incidents { get; set; }
        [JsonIgnore]
        public ICollection <ChildJournal> Journals { get; set; }
    }
}
