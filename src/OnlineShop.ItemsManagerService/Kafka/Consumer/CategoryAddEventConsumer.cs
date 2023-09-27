using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Interfaces;
using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Consumer
{
    public class CategoryAddEventConsumer : BaseEventConsumer<ItemAdd>
    {
        public CategoryAddEventConsumer(IEventHandler<ItemAdd> eventHandler, ILogger<ItemAdd> logger, BaseConsumerKafksSettings baseConsumerKafksSettings) :
            base(eventHandler, logger, baseConsumerKafksSettings, ConsumerNameEnum.CatalogAdd) { }
    }
}
