using Confluent.Kafka;
using MessageBroker.Kafka.Lib.Helpers;
using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;
using Microsoft.Extensions.Logging;
using OnlineShop.CategoryData.Models;
using System.Configuration;

namespace MessageBroker.Kafka.Lib
{
    public abstract class BaseEventProducer<T> : IBaseEventProducer<T>, IDisposable
    {
        protected IProducer<Null, T> _producer;
        protected BaseProduserKafksSettings _baseProduserKafkasSettings;
        protected ProducersKafkaSettings _producersKafkaSettings;
        private ILogger<T> _loger;

        public BaseEventProducer(BaseProduserKafksSettings baseProduserKafksSettings, ILogger<T> loger, ProducerNameEnum producersNameEnum)
        {
            _baseProduserKafkasSettings = baseProduserKafksSettings;
            _loger = loger;

            _producersKafkaSettings = _baseProduserKafkasSettings.ProducersKafkaSettings[producersNameEnum];
        }

        public async void SendMessage(Message<Null, T> message)
        {
            //var _producerKafkaSettings = _baseProduserKafkasSettings.ProducersKafkaSettings[producersNameEnum];
            Initialization();

            if (_producersKafkaSettings.Topics.Length == 0)
                throw new Exception("topics is empty");

            foreach (string topic in _producersKafkaSettings.Topics)
            {
                var result = await _producer.ProduceAsync(topic, message);
            } 
        }

        protected void Initialization()
        {
            if (_producersKafkaSettings == null)
                throw new Exception("ProducerKafkaSettings is null or Empry");

            var config = KafkaConfigHelperMaper.MapToProducerConfigKafkaHelper(_producersKafkaSettings);

            _producer = new ProducerBuilder<Null, T>(config)
                .SetValueSerializer(new BaseProtoBuf<T>(_loger))
                .Build();
        }

        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}
