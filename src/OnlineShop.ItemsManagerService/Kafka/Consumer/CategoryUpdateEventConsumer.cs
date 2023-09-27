using MessageBroker.Kafka.Lib.Option.ConsumersOption;
using MessageBroker.Kafka.Lib.Option.Enums;
using MessageBroker.Kafka.Lib;
using MessageBroker.Kafka.Lib.Interfaces;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Consumer
{
    public class CategoryUpdateEventConsumer : BaseEventConsumer<ItemUpdate>
    {
        public CategoryUpdateEventConsumer(IEventHandler<ItemUpdate> eventHandler, ILogger<ItemUpdate> logger, BaseConsumerKafksSettings baseConsumerKafksSettings) :
            base(eventHandler, logger, baseConsumerKafksSettings,  ConsumerNameEnum.CatalogUpdate) { }
    }
}
