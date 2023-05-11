using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.JournauxHandler
{
    public class UpdateJournalHandler : IRequestHandler<UpdateJournalCommand, ChildJournal>
    {
        private readonly IjournalRepository _journalRepository;

        public UpdateJournalHandler(IjournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task<ChildJournal> Handle(UpdateJournalCommand request, CancellationToken cancellationToken)
        {
            var journalDetails = _journalRepository.GetJournalById(request.JournalId);

            if (journalDetails != null)
            {
                journalDetails.JournalId = request.JournalId;
                journalDetails.LastModified = DateTime.UtcNow;
                journalDetails.ArrivalTime = request.ArrivalTime;
                journalDetails.DepartureTime = request.DepartureTime;
                journalDetails.NapStart = request.NapStart;
                journalDetails.NapEnd = request.NapEnd;
                journalDetails.repasMatin = request.repasMatin;
                journalDetails.repasMidi = request.repasMidi;
                journalDetails.Medication = request.Medication;
                _journalRepository.UpdateJournal(journalDetails);
            }

            return journalDetails;
        }
    }
}
