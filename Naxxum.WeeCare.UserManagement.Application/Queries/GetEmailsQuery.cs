using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxum.WeeCare.UserManagement.Application.Queries
{
    public record GetEmailsQuery :IRequest<List<string>>;
}
