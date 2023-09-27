using AutoMapper;
using OnlineShop.CategoryData.Interfaces;
using OnlineShop.CategoryData.Models;
using OnlineShop.CategoryData.Models.Interfaces;

namespace OnlineShop.ApiService.Helpers
{
    public static class ItemHelperMaper
    {
        private static readonly Mapper _mapper = null;

        static ItemHelperMaper() 
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Item, ItemAdd>();
                cfg.CreateMap<Item, ItemUpdate>();
                cfg.CreateMap<ImageItem, ImageItem>();
                cfg.CreateMap<Category, Category>();
                cfg.CreateMap<Item, Item>();
                cfg.CreateMap<Product, Product>();
                cfg.CreateMap<Price, Price>();
                cfg.CreateMap<ImageProduct, ImageProduct>();
            });

            _mapper = new Mapper(config);
        }

        public static ItemAdd MapToItemAddHelper<T>(T sours)
        {
            return (ItemAdd)sours;
        }

        public static ItemUpdate MapToItemUpdateHelper<T>(T sours)
        {
            return (ItemUpdate)sours;
        }

        public static IIdentifiable MapToIIdentifiableHelper<T>(T sours)
        {
            return (IIdentifiable)sours;
        }

    }
}
