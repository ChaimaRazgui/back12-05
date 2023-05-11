using MediatR;
using Naxxum.WeeCare.UserManagement.Application.Queries;
using Naxxum.WeeCare.UserManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.WeeCare.UserManagement.Application.Handlers
{
    public class GetAllParentsEmailHandler : IRequestHandler<GetEmailsQuery, List<string>>
    {
        private readonly IUserDetailsRepository _userRepository;
        public GetAllParentsEmailHandler(IUserDetailsRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<List<string>> Handle(GetEmailsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepository.GetAllParentEmails());
        }
    }
}
