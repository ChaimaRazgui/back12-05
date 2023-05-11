using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand
{
    public class DeleteIncidentCommand : IRequest<bool>
    {
        public int HealthId { get; set; }   
    }
}
