namespace UserService.Core.Options
{
    public class RabbitMqOptions
    {
        public const string DefaultName = "RabbitMqOptions";

        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ExchangeOptions ExchangeOptions { get; set; }

    }
}
