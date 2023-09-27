using MessageBroker.Kafka.Lib.Interfaces;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Models.Interfaces;
using OnlineShop.ItemsManagerService.Kafka.Helpers;
using OnlineShop.ItemsManagerService.Services.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Handlers
{
    public class CategoryAddEventHandler : IEventHandler<ItemAdd>
    {
        private readonly IServeces<Item> _itemService;
        public CategoryAddEventHandler(IServeces<Item> itemService)
        {
            _itemService = itemService;
        }
        public void HandleAsync(ItemAdd consumerContext)
        {
            var item = KafkaItemHelperMaper.MapToItemKafkaHelper(consumerContext);
            _itemService.AddAsync(item);
        }
    }
}
 