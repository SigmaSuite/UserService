using System.Threading.Tasks;

namespace UserService.Core.MessageBroker.Interfaces
{
    public interface IMessagePublisher
    {
        public Task Publish(string message);
    }
}
