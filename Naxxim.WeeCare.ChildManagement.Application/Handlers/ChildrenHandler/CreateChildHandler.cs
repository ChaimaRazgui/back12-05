using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Naxxim.WeeCare.ChildManagement.Application.Commands.ChildrenCommand;
using Naxxim.WeeCare.ChildManagement.Application.DTOs;
using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Naxxim.WeeCare.ChildManagement.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Handlers.ChildrenHandler
{
    public class CreateChildHandler : IRequestHandler<CreateChildCommand, Result>
    {
        private readonly ILogger<CreateChildHandler> _logger;
        private readonly IChildRepository _childRepository;
        private readonly IRMQParentVerification _parentVerification;
        private readonly ParentIdConsumer _ParentIdConsumer;
        private dynamic _receivedUserData;

        public CreateChildHandler(
            ILogger<CreateChildHandler> logger,
            IChildRepository childRepository,
            IRMQParentVerification parentVerification,
            ParentIdConsumer parentIdConsumer)
        {
            _logger = logger;
            _childRepository = childRepository;
            _parentVerification = parentVerification;
            _ParentIdConsumer = parentIdConsumer;
        }

        public async Task<Result> Handle(CreateChildCommand request, CancellationToken cancellationToken)
        {


            _parentVerification.SendMessage(request.ParentEmail);
            _logger.LogInformation($"the email sending is {request.ParentEmail}");
            _ParentIdConsumer.MessageReceived += OnMessageReceived;

            while (_receivedUserData is null)
            {
                await Task.Delay(100);
            }
            _logger.LogInformation("the parentid is here");
            if (_receivedUserData is int Parentid && Parentid != -1)
            {
                _logger.LogInformation("Creating new Child");
                var child = new Child
                {
                    ChildId = request.ChildId,
                    UniqueCode = $"{request.Firstname[0]}{request.Lastname[0]}{Guid.NewGuid().ToString().Substring(0, 4)}",
                    LastName = request.Lastname,
                    FirstName = request.Firstname,
                    DateOfBirth = request.DateOfBirth,
                    allergy = request.allergy,
                    chronic_illness = request.chronic_illness,
                    ParentId = Parentid
                };

                await _childRepository.CreateChild(child);

                return new Result { StatusCode = 200, Message = "Child created successfully." };
            }
            else
            {
                return new Result { StatusCode = 400, Message = "No such a parent with the provided Email" };
            }
        }

        private void OnMessageReceived(object sender, ParentChild e)
        {
            _logger.LogInformation($"Received message from RabbitMQ: Message={e}");
            // Do something with the received message 
            _receivedUserData = e.ParentId;
        }
    }
}