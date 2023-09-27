using MessageBroker.Kafka.Lib.Interfaces;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Models.Interfaces;
using OnlineShop.ItemsManagerService.Kafka.Helpers;
using OnlineShop.ItemsManagerService.Services.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Handlers
{
    public class CategoryUpdateEventHandler : IEventHandler<ItemUpdate>
    {
        private readonly IServeces<Item> _itemService;

        public CategoryUpdateEventHandler(IServeces<Item> itemService)
        {
            _itemService = itemService;
        }

        public void HandleAsync(ItemUpdate consumerContext)
        {
            var item = KafkaItemHelperMaper.MapToItemKafkaHelper(consumerContext);
            _itemService.SaveAsync(item);
        }
    }
}
