using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Queries.IncidentsQueries
{
    public record GetAllIncidentsQuery : IRequest<List<ChildwithUniquecodeIncident>>;
   
}
