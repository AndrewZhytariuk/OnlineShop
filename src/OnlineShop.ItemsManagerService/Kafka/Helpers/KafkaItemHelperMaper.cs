using AutoMapper;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ItemsManagerService.Kafka.Helpers
{
    public static class KafkaItemHelperMaper
    {
        private static readonly Mapper _mapper = null;

        static KafkaItemHelperMaper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItemUpdate, Item>();
                cfg.CreateMap<ItemAdd, Item>();
                cfg.CreateMap<ImageItem, ImageItem>();
                cfg.CreateMap<Category, Category>();
                cfg.CreateMap<Item, Item>();
                cfg.CreateMap<Product, Product>();
                cfg.CreateMap<Price, Price>();
                cfg.CreateMap<ImageProduct, ImageProduct>();
            });

            _mapper = new Mapper(config);
        }

        public static Item MapToItemKafkaHelper<T>(T sours)
        {
            return _mapper.Map<Item>(sours);
        }
    }
}
