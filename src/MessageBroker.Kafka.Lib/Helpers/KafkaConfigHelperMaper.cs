using AutoMapper;
using Confluent.Kafka;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;

namespace MessageBroker.Kafka.Lib.Helpers
{
    public static class KafkaConfigHelperMaper
    {
        private static readonly Mapper _mapper = null;
        static KafkaConfigHelperMaper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ConsumerKafkaSettings, ConsumerConfig>();
                    cfg.CreateMap<ProducersKafkaSettings, ProducerConfig>();
                }
            );
            _mapper = new Mapper(config);
        }

        public static ConsumerConfig MapToConsumerConfigKafkaHelper<T>(T sours)
        {
                return _mapper.Map<ConsumerConfig>(sours);
        }
        
        public static ProducerConfig MapToProducerConfigKafkaHelper<T>(T sours)
        {
            return _mapper.Map<ProducerConfig>(sours);
        }
    }
}
