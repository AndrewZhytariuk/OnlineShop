using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;

namespace OnlineShop.ApiService.AppStart.ConfigureServices
{
    public static class ConfigureServicesKafka
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var producersKafkaSettings = new Dictionary<ProducerNameEnum, ProducersKafkaSettings>();
            configuration.GetSection(ProducersKafkaSettings.ProducersKafkaName).Bind(producersKafkaSettings);

            services.AddSingleton<BaseProduserKafksSettings>(x => new BaseProduserKafksSettings(producersKafkaSettings));
        }
    }
}
