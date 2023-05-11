using Microsoft.Extensions.Logging;
using Naxxum.WeeCare.UserManagement.Application.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Naxxum.WeeCare.UserManagement.Application.DTOs;
using Naxxum.WeeCare.UserManagement.Domain.Entites;

namespace Naxxum.WeeCare.UserManagement.Infrastructrue.Repositories
{
    public class ChildService : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<TokenService> _logger;
        private readonly IRabitMQProducerD _rabitMQProducer;
        public ChildService(IServiceProvider serviceProvider, ILogger<TokenService> logger, IRabitMQProducerD rabitMQProducer)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;

            // create the RabbitMQ connection
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();

            // create the channel
            _channel = _connection.CreateModel();

            // declare the queue
            _channel.QueueDeclare("parentEmail", exclusive: false);
            // set up a consumer to listen for messages on the queue
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageReceived;
            _channel.BasicConsume(queue: "parentEmail", autoAck: true, consumer: consumer);
            _rabitMQProducer = rabitMQProducer;
        }

        private void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray(); // Use ToArray() to convert ReadOnlyMemory<byte> to byte[]
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation($"Received email: {message}");
            var Email = JsonConvert.DeserializeObject<string>(message);
            _logger.LogInformation($"Received email: {Email}");
            using (var scope = _serviceProvider.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetService<IUserDetailsRepository>();
                var user = userRepository.GetUserByEmail(Email);

                if (user is not null)
                {
                    var parentid = new ParentChild
                    {
                        ParentId = user.UserId
                    };
                    _rabitMQProducer.SendParentId(parentid);
                }
                else
                {
                    var parentid = new ParentChild
                    {
                        ParentId = -1
                    };
                    _rabitMQProducer.SendParentId(parentid);
                    _logger.LogError($"User with id {Email} not found");
                    _rabitMQProducer.SendParentId(parentid);
                }
            }
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
