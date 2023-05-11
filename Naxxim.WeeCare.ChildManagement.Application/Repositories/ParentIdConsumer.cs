using Microsoft.Extensions.Logging;
using Naxxim.WeeCare.ChildManagement.Domain.Entites;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Application.Repositories
{
    public class ParentIdConsumer : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ParentIdConsumer> _logger;

        public ParentIdConsumer(IServiceProvider serviceProvider, ILogger<ParentIdConsumer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger; ;
            // create the RabbitMQ connection
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();

            // create the channel
            _channel = _connection.CreateModel();

            // declare the queue
            _channel.QueueDeclare("ParentId", exclusive: false);
            // set up a consumer to listen for messages on the queue
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageReceived;
            _channel.BasicConsume(queue: "ParentId", autoAck: true, consumer: consumer);
        }

        public event EventHandler<ParentChild> MessageReceived;

        private void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation($"Received data : {message}");

             var userdata = JsonConvert.DeserializeObject<ParentChild>(message);
             Console.WriteLine($"Received message: ParentId={userdata}");
            var parentDetails = new ParentChild
            {
                ParentId = userdata.ParentId

            };
            MessageReceived?.Invoke(this, parentDetails);
               
          
        }


        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
