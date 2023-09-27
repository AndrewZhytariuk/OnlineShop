using Confluent.Kafka;
using AutoMapper;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib.Interfaces;
using MessageBroker.Kafka.Lib.Helpers;
using Microsoft.Extensions.Logging;
using Akka.Event;

namespace MessageBroker.Kafka.Lib
{
    public abstract class BaseEventConsumer<T> : IBaseEventConsumer<T>, IDisposable
    {
        private IConsumer<Null, T> _consumer;
        private readonly IEventHandler<T> _eventHandler = null;
        protected ConsumerKafkaSettings _consumerKafkaSettings;
        protected ConsumerConfig config;
        private ILogger<T> _logger;

        public BaseEventConsumer(IEventHandler<T> eventHandler, ILogger<T> logger, BaseConsumerKafksSettings baseConsumerKafksSettings, ConsumerNameEnum consumerNameEnum)
        {
            _consumerKafkaSettings = baseConsumerKafksSettings.ConsumerKafkaSettings[consumerNameEnum];
            _eventHandler = eventHandler;
            _logger = logger;

            Initialization();
            DoConsumer();
        }

        protected void Initialization()
        {
            if (_consumerKafkaSettings == null)
                throw new Exception("Consumer Kafka Settings is not empty");

            config = KafkaConfigHelperMaper.MapToConsumerConfigKafkaHelper(_consumerKafkaSettings);

            _consumer = InitializationConsumer(config);

            SubscribeOnTopic<T>(_consumerKafkaSettings.Topics);
            Task.Run(() => HandleAsync());
        }

        private void DoConsumer()
        {
            SubscribeOnTopic<T>(_consumerKafkaSettings.Topics);
            Task.Run(() => HandleAsync());
        }

        public void SubscribeOnTopic<T>(string[] topics)
        {
            foreach(string topic in topics)
                _consumer.Subscribe(topic);
        }

        private IConsumer<Null, T> InitializationConsumer(ConsumerConfig config)
        {
            var _consumer = new ConsumerBuilder<Null, T>(config)
                .SetValueDeserializer(new BaseProtoBuf<T>(_logger))
                .Build();

            return _consumer;
        }

        private void HandleAsync()
        {
            using (_consumer)
            {
                while (true)
                {
                    ConsumeResult<Null, T> result = _consumer.Consume(500);

                    if (result != null && result.Value != null)
                            _eventHandler.HandleAsync(result.Value);
                }
            }
        }

        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }
}
