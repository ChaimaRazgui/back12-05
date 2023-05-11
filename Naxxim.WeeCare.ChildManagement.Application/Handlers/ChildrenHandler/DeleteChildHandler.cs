using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler
{
    internal class DeleteChildHandler : IRequestHandler<DeleteChildCommand, bool>
    {
        private readonly IChildRepository _childRepository;

        public DeleteChildHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }
        public Task<bool> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            var childDetails = _childRepository.GetChildById(request.ChildId);
            return Task.FromResult(_childRepository.DeleteChild(childDetails.ChildId));

        }
    }
}
