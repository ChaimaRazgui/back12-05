using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler
{
    public class UpdateChildHandler : IRequestHandler<UpdateChildCommand, Child>
    {
        private readonly IChildRepository _childRepository;

        public UpdateChildHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<Child> Handle(UpdateChildCommand request, CancellationToken cancellationToken)
        {
            var childDetails = _childRepository.GetChildById(request.ChildId);

            if (childDetails != null)
            {
                childDetails.allergy = request.allergy;
                childDetails.chronic_illness = request.chronic_illness;
                childDetails.DateOfBirth = request.DateOfBirth;
                childDetails.FirstName = request.FirstName;
                childDetails.LastName = request.LastName;

                _childRepository.UpdateChild(childDetails);
            }

            return childDetails;
        }
    }
}
