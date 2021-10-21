using System.Threading.Tasks;

namespace UserService.Core.MessageBroker.Interfaces
{
    public interface IMessagePublisher
    {
        public void Publish(string message);
    }
}
