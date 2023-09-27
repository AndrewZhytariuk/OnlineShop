using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;
using OnlineShop.CategoryData.Interfaces;

namespace OnlineShop.ApiService.Kafka.Producers.ItemProducers
{
    public class ItemDeleteEventProducer : BaseEventProducer<IIdentifiable>
    {
        public ItemDeleteEventProducer(BaseProduserKafksSettings baseProduserKafksSettings, ILogger<IIdentifiable> logger) : base(baseProduserKafksSettings, logger, ProducerNameEnum.CatalogDelete) { }
    }
}
