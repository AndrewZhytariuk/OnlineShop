using MessageBroker.Kafka.Lib.Interfaces;
using OnlineShop.ItemsManagerService.Services.Interfaces;
using OnlineShop.CategoryData.Interfaces;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.ItemsManagerService.Kafka.Handlers
{
    public class CategoryDeleteEventHandler : IEventHandler<IIdentifiable>
    {
        private readonly IServeces<Item> _itemService;

        public CategoryDeleteEventHandler(IServeces<Item> itemService) {
            _itemService = itemService;
        }

        public void HandleAsync(IIdentifiable consumerContext)
        {
            _itemService.DeleteAsync(consumerContext.Id);
        }
    }
}
