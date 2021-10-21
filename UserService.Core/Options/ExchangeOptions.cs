using UserService.Core.Enums;

namespace UserService.Core.Options
{
    public class ExchangeOptions
    {
        public string VirtualHost { get; set; }
        public string Name { get; set; }
        public ExchangeType ExchangeType { get; set; }
        public bool Durability { get; set; }
        public bool AutoDelete { get; set; }
        public bool Internal { get; set; }
    }
}
