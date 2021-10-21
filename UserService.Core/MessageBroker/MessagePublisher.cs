using Microsoft.Extensions.Options;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using UserService.Core.MessageBroker.Interfaces;
using UserService.Core.Options;

namespace UserService.Core.MessageBroker
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IQueueService _QueueService;
        private readonly RabbitMqOptions rabbitMqOptions;

        public MessagePublisher(IQueueService queueService, IOptions<RabbitMqOptions> rabbitMqOptions)
        {
            _QueueService = queueService;
            this.rabbitMqOptions = rabbitMqOptions.Value;
        }

        public void Publish(string message)
        {
            //_QueueService.Channel.ExchangeDeclare(rabbitMqOptions.Exchange, )


            _QueueService.Channel.QueueDeclare("test", false, false, false, null);
            _QueueService.Channel.BasicPublish("", "test", false, null, System.Text.Encoding.UTF8.GetBytes(message));
        }

        private void SetupExchange()
        {
            _QueueService.Channel.ExchangeDeclare(rabbitMqOptions.ExchangeOptions.Name, rabbitMqOptions.ExchangeOptions.ExchangeType.ToString(), rabbitMqOptions.ExchangeOptions.Durability, rabbitMqOptions.ExchangeOptions.AutoDelete, null);
        }
    }
}
