using MediatR;
using Microsoft.Extensions.Logging;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler;
using Naxxim.WeeCare.ChildManagement.Application.Queries.JournalQueries;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.JournauxHandler
{
    public class GetAllJournalsHandler : IRequestHandler<GetAllJournalsQuery, List<Journalwithuniquecode>>
    {
        private readonly IjournalRepository _journalRepository;
        private readonly IChildRepository _childRepository;
        private readonly ILogger<GetAllJournalsHandler> _logger;
        public GetAllJournalsHandler(IjournalRepository journaRepository, IChildRepository childRepository, ILogger<GetAllJournalsHandler> logger)
        {
            _journalRepository = journaRepository;
            _childRepository = childRepository;
            _logger = logger;
        }
        public async Task<List<Journalwithuniquecode>> Handle(GetAllJournalsQuery request, CancellationToken cancellationToken)
        {
            var Listejournals = new List<Journalwithuniquecode>();
            var journals = _journalRepository.GetAllJournals();
            foreach (var journal in journals)
            {
                var child = _childRepository.GetChildById(journal.IdChild);
                if (child != null)
                {
                    var newJournal = new Journalwithuniquecode
                    {
                        JournalId = journal.JournalId,
                        UniqueCode = child.UniqueCode,
                        ArrivalTime = journal.ArrivalTime,
                        DepartureTime = journal.DepartureTime,
                        LastModified = journal.LastModified.ToString("yyyy-MM-dd HH:mm"),
                        NapStart = journal.NapStart,
                        NapEnd = journal.NapEnd,
                        repasMatin = journal.repasMatin,
                        repasMidi = journal.repasMidi,
                        Medication = journal.Medication,

                    };
                    Listejournals.Add(newJournal);
                }
            }
            return Listejournals;
        }
    }
}
