using RabbitMQ.Client;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;
using System.Text;
using System.Threading.Tasks;
using UserService.Core.MessageBroker.Interfaces;

namespace UserService.Core.MessageBroker
{
    public class MessagePublisher : IMessagePublisher
    {
        //private readonly IQueueService _QueueService;

        //public MessagePublisher(IQueueService queueService)
        //{
            //_QueueService = queueService;
        //}

        public async Task Publish(string message)
        {
            Console.WriteLine("Sending message ;]");

            var factory = new ConnectionFactory() { HostName = "rabbitmq" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "default",
                                     routingKey: "defaultqueueroutingkey",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);

            }
        }
    }
}
