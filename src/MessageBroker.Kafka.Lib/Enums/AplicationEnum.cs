namespace MessageBroker.Kafka.Lib.Enums
{
    public static partial class ApplicationEnum
    {
        public enum Acks
        {
            None = 0,
            Leader = 1,
            All = -1
        }
    }
}
