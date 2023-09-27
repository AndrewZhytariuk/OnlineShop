namespace MessageBroker.Kafka.Lib
{
    public interface IBaseEventConsumer<T>
    {
        public void SubscribeOnTopic<T>(string[] topics); //where T : class;
        public void Dispose();
    }
}
