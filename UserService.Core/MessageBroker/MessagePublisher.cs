using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using System;
using UserService.Core.Enums;
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

        public void Publish(Message message)
        {
            SetupExchange();
            SetupDefaultQueue();
            _QueueService.Channel.BasicPublish(rabbitMqOptions.ExchangeOptions.Name, 
                                               rabbitMqOptions.DefaultQueueOptions.DefaultRoutingKey, 
                                               false, 
                                               null, 
                                               System.Text.Encoding.UTF8.GetBytes(message.GetJson()));
        }

        private void SetupExchange()
        {
            _QueueService.Channel.ExchangeDeclare(rabbitMqOptions.ExchangeOptions.Name,
                                                  rabbitMqOptions.ExchangeOptions.ExchangeType.ToString(),
                                                  rabbitMqOptions.ExchangeOptions.Durability,
                                                  rabbitMqOptions.ExchangeOptions.AutoDelete,
                                                  null);
        }

        private void SetupDefaultQueue()
        {
            _QueueService.Channel.QueueDeclare(rabbitMqOptions.DefaultQueueOptions.Name, rabbitMqOptions.DefaultQueueOptions.Durability,
                                               rabbitMqOptions.DefaultQueueOptions.Exclusive,
                                               rabbitMqOptions.DefaultQueueOptions.AutoDelete,
                                               null);
            _QueueService.Channel.QueueBind(rabbitMqOptions.DefaultQueueOptions.Name, 
                                            rabbitMqOptions.ExchangeOptions.Name, 
                                            rabbitMqOptions.DefaultQueueOptions.
                                            DefaultRoutingKey, null);
        }
    }
}
