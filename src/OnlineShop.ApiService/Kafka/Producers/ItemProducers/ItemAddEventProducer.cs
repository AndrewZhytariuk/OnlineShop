using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib.Option.ProdusersOption;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ApiService.Kafka.Producers.ItemProducers
{
    public class ItemAddEventProducer : BaseEventProducer<ItemAdd>
    {
        public ItemAddEventProducer(BaseProduserKafksSettings baseProduserKafksSettings, ILogger<ItemAdd> loger) : base(baseProduserKafksSettings, loger, ProducerNameEnum.CategoryAdd) { }
    }
}
