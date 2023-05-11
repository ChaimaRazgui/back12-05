using MediatR;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand
{
    public class UpdateChildCommand : IRequest<Child>
    {
        public int ChildId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? allergy { get; set; }
        public string? chronic_illness { get; set; }
    }
}
