using MediatR;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand
{
    public class CreateJournalCommand : IRequest<Result>
    {
        public int JournalId { get; set; }
        public string? ArrivalTime { get; set; }
       
        public string? UniqueCode { get; set; }
       
    }
}
