namespace UserService.Core.Options
{
    public class DefaultQueueOptions
    {
        public string Name { get; set; }
        public string DefaultRoutingKey { get; set; }
        public bool Durability { get; set; }
        public bool AutoDelete { get; set; }
        public bool Internal { get; set; }
        public bool Exclusive { get; set; }
    }
}
