using MessageBroker.Kafka.Lib.Option.Enums;
using static MessageBroker.Kafka.Lib.Enums.ApplicationEnum;

namespace MessageBroker.Kafka.Lib.Option.ProdusersOption
{
    public class ProducersKafkaSettings
    {
        public const string ProducersKafkaName = nameof(ProducersKafkaSettings);
        public ProducerNameEnum ProducerName { get; set; }
        public int MessageSendMaxRetries { get; set; }
        public bool EnableDeliveryReports { get; set; }
        public int RetryBackoffMs { get; set; }
        public bool EnableIdempotence { get; set; }
        public int BatchNumMessages { get; set; }
        public string[] Topics { get; set; }
        public string BootstrapServers { get; set; }
        public Acks Acks { get; set; }
    }
}
