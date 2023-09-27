using Confluent.Kafka;
using ProtoBuf;
using static MessageBroker.Kafka.Lib.Enums.ApplicationEnum;
using Akka.Remote.Serialization;

namespace MessageBroker.Kafka.Lib
{
    public abstract class MessageBusBase<T> : IDisposable
    {
        protected readonly IProducer<Null, T> _producer;
        protected readonly IConsumer<Null, T> _consumer;

        protected readonly IDictionary<string, object> _producerConfig;
        protected readonly IDictionary<string, object> _consumerConfig;

        protected abstract void InitializationProducer();
        protected abstract void InitializationConsumer();

        public MessageBusBase() { }

        public MessageBusBase(string brokerEndpoint, Enums.ApplicationEnum.Acks acks)
        {
            _producerConfig = new Dictionary<string, object> { 
                { "bootstrap.servers", brokerEndpoint },
                { "default.topic.config",
                    new Dictionary<string, object>
                    {
                        { "message.timeout.ms", 500 },
                        { "request.required.acks", acks }
                    }
                }
            };

            _consumerConfig = new Dictionary<string, object>
            {
                { "group.id", "custom-group"},
                { "bootstrap.servers", brokerEndpoint }
            };

            InitializationProducer();
            InitializationConsumer();
            //_producer = new ProducerBuilder<Null, string>((IEnumerable<KeyValuePair<string, string>>)_producerConfig)
            //    .SetValueSerializer(new ProtobufSerializer<T>())
            //    .Build();
            //_producer = new ProducerBuild //new Producer<Null, string>(_producerConfig, new NullSerializer(), new StringSerializer(Encoding.UTF8));
        }

        public void SendMessage(string topic, Message<Null, T> message)
        {
           _producer.ProduceAsync(topic, message);
        }

        public void SubscribeOnTopic<T>(string topic, Action<T> action, CancellationToken cancellationToken, string host, Enums.ApplicationEnum.Acks acks) where T : class 
        {
            //var msgBus = new MessageBusBase(host, acks);
            //using (msgBus._consumer = new Consumer<Null, string>(_consumerConfig, null, new StringDeserializer(Encoding.UTF8)))

            using (_consumer)
            {
                _consumer.Assign(new List<TopicPartitionOffset> { new TopicPartitionOffset(topic, 0, -1) });

                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    var msg = _consumer.Consume(TimeSpan.FromMilliseconds(10));
                    if (msg != null)
                    {
                        action(msg.Value as T);
                    }
                }
            }
        }

        public void Dispose()
        {
            _producer?.Dispose();
            _consumer?.Dispose();
        }
    }
}
