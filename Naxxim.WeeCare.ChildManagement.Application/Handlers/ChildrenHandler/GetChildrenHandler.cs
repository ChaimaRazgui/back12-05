using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler
{
    public class GetChildrenHandler : IRequestHandler<GetChildren, List<Child>>
    {
        private readonly IChildRepository _childRepository;
        public GetChildrenHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }
        public Task<List<Child>> Handle(GetChildren request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_childRepository.GetChildren());
        }
    }
}
