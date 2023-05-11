using MediatR;
using Microsoft.AspNetCore.Mvc;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand
{
    public class CreateChildCommand : IRequest<Result>
    {
        public int ChildId { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? allergy { get; set; }
        public string? chronic_illness { get; set; }
        public string? ParentEmail { get; set; }
    }
}
