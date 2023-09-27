using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ApiService.Kafka.Producers.ItemProducers
{
    public class ItemUpdateEventProducer : BaseEventProducer<ItemUpdate>
    {
        public ItemUpdateEventProducer(BaseProduserKafksSettings baseProduserKafksSettings, ILogger<ItemUpdate> logger) : base(baseProduserKafksSettings, logger, ProducerNameEnum.CatalogUpdate) { }
    }
}