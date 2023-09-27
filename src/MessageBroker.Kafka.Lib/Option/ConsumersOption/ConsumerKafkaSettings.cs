using MessageBroker.Kafka.Lib.Option.Enums;
using static MessageBroker.Kafka.Lib.Enums.ApplicationEnum;

namespace MessageBroker.Kafka.Lib.Option.ConsumersOption
{
    public class ConsumerKafkaSettings
    {
        public const string ConsumerKafkaName = nameof(ConsumerKafkaSettings);
        public ConsumerNameEnum ConsumerName { get; set; }
        public int MessageSendMaxRetries { get; set; }
        public int RetryBackoffMs { get; set; }
        public string[] Topics { get; set; }
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
        public Acks Acks { get; set; }
    }
}
