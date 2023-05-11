using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Queries.ChildrenQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler
{
    public class GetAllChidrenIdHandler : IRequestHandler<GetAllChildrenId, List<string>>
    {
        private readonly IChildRepository _childRepository;
        public GetAllChidrenIdHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }
        public Task <List<string>> Handle(GetAllChildrenId request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_childRepository.GetAllChildsId());
            }
}
}
