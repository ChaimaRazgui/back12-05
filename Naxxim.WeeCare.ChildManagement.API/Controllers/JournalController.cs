using MediatR;
using Microsoft.AspNetCore.Mvc;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Queries.IncidentsQueries;
using Naxxim.WeeCare.ChildManagement.Application.Queries.JournalQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using Naxxim.WeeCare.ChildManagement.Infrastructure.Repositories;

namespace Naxxim.WeeCare.ChildManagement.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class JournalController : Controller
         
    {
        private readonly IMediator _mediator;
        private readonly IChildRepository _childRepository;
        private readonly IjournalRepository _journalRepository;
        public JournalController(IMediator mediator, IChildRepository childRepository,IjournalRepository journalRepository) 
        {
            _mediator = mediator; 
            _childRepository= childRepository;
            _journalRepository= journalRepository;
        }
        [HttpPost("createJournal")]
        public async Task<Result> CreateIncident(CreateJournalCommand journalDto)
        {

            return await _mediator.Send(journalDto);

        }
        [HttpGet("AllJournal")]
        public async Task<List<Journalwithuniquecode>> GetJournals()
        {
            return await _mediator.Send(new GetAllJournalsQuery());
        }
        [HttpPut("UpdateJournal")]
        public async Task<ActionResult<ChildJournal>> updateJournal(UpdateJournalCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("deleteJournal")]
        public async Task<bool> DeleteJournal(int journalId)
        {
            return await _mediator.Send(new DeleteJournalCommand() { JournalId = journalId });
        }
        [HttpGet("ParentChildJournal")]
        public IActionResult GetJournalsByParentId(int parentId)
        {
            var childs = _childRepository.GetChildbyParentId(parentId);
            if (childs.Count == 0)
            {
                return NotFound();
            }

            var alljournal = new List<JournalDTO>();
            foreach (var child in childs)
            {
                var childJournals = _journalRepository.GetJournalsByChildId(child.ChildId);
                if (childJournals is not null)
                {
                    foreach (var journal in childJournals)
                    {
                        var journalDTO = new JournalDTO
                        {
                            LastName = child.LastName,
                            FirstName = child.FirstName,
                            ArrivalTime = journal.ArrivalTime,
                            DepartureTime = journal.DepartureTime,
                            LastModified = journal.LastModified.ToString("yyyy-MM-dd HH:mm"),
                            NapStart = journal.NapStart,
                            NapEnd = journal.NapEnd,
                            repasMatin = journal.repasMatin,
                            repasMidi = journal.repasMidi,
                            Medication = journal.Medication,
                        };

                        alljournal.Add(journalDTO);
                    }
                }
            }

            return Ok(alljournal);
        }
    }
}
