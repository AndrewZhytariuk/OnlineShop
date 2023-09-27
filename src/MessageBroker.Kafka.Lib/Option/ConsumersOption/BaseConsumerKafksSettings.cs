using MessageBroker.Kafka.Lib.Option.Enums;

namespace MessageBroker.Kafka.Lib.Option.ConsumersOption
{
    public class BaseConsumerKafksSettings
    {

        public Dictionary<ConsumerNameEnum, ConsumerKafkaSettings> ConsumerKafkaSettings { get; set; }
        public BaseConsumerKafksSettings(Dictionary<ConsumerNameEnum, ConsumerKafkaSettings> consumerKafkaSettings) {
            ConsumerKafkaSettings = consumerKafkaSettings;
        }
    }
}
