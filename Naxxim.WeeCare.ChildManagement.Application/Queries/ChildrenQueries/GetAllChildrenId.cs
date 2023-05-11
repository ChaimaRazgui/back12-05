using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries
{
    public record GetAllChildrenId : IRequest<List<string>>;
  
}
