using Naxxim.WeeCare.ChildManagement.Application.Repositories;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naxxim.WeeCare.ChildManagement.Infrastructure.Repositories
{
    public class RMQParentVerification : IRMQParentVerification
    {
        public void SendMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection 
            var connection = factory.CreateConnection();
            //create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the queue
            channel.QueueDeclare("parentEmail", exclusive: false);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the queue
            channel.BasicPublish(exchange: "", routingKey: "parentEmail", body: body);
        }
    }
}
