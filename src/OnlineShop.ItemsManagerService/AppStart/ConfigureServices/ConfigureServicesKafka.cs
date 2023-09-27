using Confluent.Kafka;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using System.Linq;
using Newtonsoft.Json;

namespace OnlineShop.ItemsManagerService.AppStart.ConfigureServices
{
    public static class ConfigureServicesKafka
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var consumersKafkaSettings = new Dictionary<ConsumerNameEnum, ConsumerKafkaSettings>();

            configuration.GetSection(ConsumerKafkaSettings.ConsumerKafkaName).Bind(consumersKafkaSettings);

            services.AddSingleton<BaseConsumerKafksSettings>(x => new BaseConsumerKafksSettings(consumersKafkaSettings));
        }
    }
}
