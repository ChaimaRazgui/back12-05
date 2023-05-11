using MediatR;
using Microsoft.Extensions.Logging;
using Naxxim.WeeCare.ChildManagement.Application.Commands.IncidentCommand;
using Naxxim.WeeCare.ChildManagement.Application.Commands.JournalsCommand;
using Naxxim.WeeCare.ChildManagement.Application.Handlers.IncidentsHandler;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.JournauxHandler
{
    public class CreateJournalHandler : IRequestHandler<CreateJournalCommand, Result>
    {
        private readonly IjournalRepository _journalRepository;
        private readonly IChildRepository _childRepository;
        private readonly ILogger<CreateIncideentHandler> _logger;
        public CreateJournalHandler(IjournalRepository journaRepository, IChildRepository childRepository, ILogger<CreateIncideentHandler> logger)
        {
            _journalRepository = journaRepository;
            _childRepository = childRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(CreateJournalCommand request, CancellationToken cancellationToken)
        {
            var child = _childRepository.GetChildByUniqueId(request.UniqueCode);
            var JournalDetails = new ChildJournal
            {
                JournalId = request.JournalId,
                LastModified = DateTime.UtcNow,
                ArrivalTime = request.ArrivalTime,
                IdChild = child.ChildId
            };

            await _journalRepository.CreateJournal(JournalDetails);

            return new Result { StatusCode = 200, Message = "Journal created successfully." };
        }



    }
}
