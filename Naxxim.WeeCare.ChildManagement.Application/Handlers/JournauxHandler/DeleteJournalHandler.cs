using MediatR;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.JournauxHandler
{
    public class DeleteJournalHandler : IRequestHandler<DeleteJournalCommand, bool>
    {
        private readonly IjournalRepository _journalRepository;

        public DeleteJournalHandler(IjournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public Task<bool> Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
    {
            var journalDetails = _journalRepository.GetJournalById(request.JournalId);
            return Task.FromResult(_journalRepository.DeleteJournal(journalDetails.JournalId));
    }
}
}
