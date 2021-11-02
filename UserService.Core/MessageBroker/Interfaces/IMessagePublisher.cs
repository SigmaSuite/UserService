using UserService.Core.Enums;

namespace UserService.Core.MessageBroker.Interfaces
{
    public interface IMessagePublisher
    {
        public void Publish(Message message);
    }
}
