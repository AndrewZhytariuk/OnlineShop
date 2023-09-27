using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using OnlineShop.Lib.Logging;

namespace MessageBroker.Kafka.Lib
{
    public class BaseProtoBuf<T> : ISerializer<T>, IDeserializer<T>
    {
        protected readonly ILogger<T> _logger;

        public BaseProtoBuf(ILogger<T> logger)
        {
            _logger = logger;
        }

        public byte[] Serialize(T data, SerializationContext context)
        {
            if (data == null) return default;

            try
            {
                using (var stream = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(stream, data);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                    .WithClass(nameof(T))
                    .WithMethod("Serialize")
                    .WithComment(ex.ToString())
                    .ToString()
                    );

                return default;
            }
        }

        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (data == null) return default(T);

            try
            {
                using (var stream = new MemoryStream(data.ToArray()))
                {
                    return ProtoBuf.Serializer.Deserialize<T>(stream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(new LogEntry()
                  .WithClass(nameof(T))
                  .WithMethod("Deserialize")
                  .WithComment(ex.ToString())
                  .ToString()
                  );

                return default(T);
            }
        }
    }
}
