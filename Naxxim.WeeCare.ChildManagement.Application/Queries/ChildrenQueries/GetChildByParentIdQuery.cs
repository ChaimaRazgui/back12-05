using MediatR;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries
{
    public class GetChildByParentIdQuery : IRequest<List<Child>>
    {
        public int parentId { get; set; }
    }

}
