using Newtonsoft.Json;

namespace UserService.Core.MessageBroker
{
    public class Message
    {
        public string Payload { get; }
        public string MessageType { get; }
        public Message(string payload, string messageType)
        {
            Payload = payload;
            MessageType = messageType;
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
