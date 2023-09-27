using Confluent.Kafka;

namespace MessageBroker.Kafka.Lib
{
    public interface IBaseEventProducer<T>
    {
        public void SendMessage(Message<Null, T> message);
        public void Dispose();
    }
}
