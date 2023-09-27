namespace MessageBroker.Kafka.Lib.Interfaces
{
    public interface IEventHandler<TValue>
    {
        void HandleAsync(TValue consumerContext);
    }
}
