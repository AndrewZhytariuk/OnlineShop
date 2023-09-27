using MessageBroker.Kafka.Lib.Option.Enums;

namespace MessageBroker.Kafka.Lib.Option.ProdusersOption
{
    public class BaseProduserKafksSettings
    {
        public Dictionary<ProducerNameEnum, ProducersKafkaSettings> ProducersKafkaSettings { get; set; }
        public BaseProduserKafksSettings(Dictionary<ProducerNameEnum, ProducersKafkaSettings> producersKafkaSettings)
        {
            ProducersKafkaSettings = producersKafkaSettings;
        }
    }
}
