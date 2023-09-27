using MessageBroker.Kafka.Lib.Interfaces;
using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using OnlineShop.CategoryData.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Consumer
{
    public class CategoryDeleteEventConsumer : BaseEventConsumer<IIdentifiable>
    {
        public CategoryDeleteEventConsumer(IEventHandler<IIdentifiable> eventHandler, ILogger<IIdentifiable> loger, BaseConsumerKafksSettings baseConsumerKafksSettings) :
                base(eventHandler, loger, baseConsumerKafksSettings, ConsumerNameEnum.CatalogRemove) { }
    }
}
