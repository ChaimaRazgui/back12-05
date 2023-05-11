using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.DTOs
{
    public record ChildDTO(int ChildId ,string Lastname, string Firstname, DateTime DateOfBirth,string allergy ,string chronic_illness,
    [Required, StringLength(100)] [EmailAddress] string ParentEmail) : IRequest;
}
