using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Queries.JournalQueries
{
    public record GetAllJournalsQuery :IRequest<List<Journalwithuniquecode>>;
    
}
