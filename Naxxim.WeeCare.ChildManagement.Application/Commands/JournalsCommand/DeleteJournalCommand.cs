using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand
{
    public class DeleteJournalCommand : IRequest<bool>
    {
        public int JournalId { get; set; }
    }
}
