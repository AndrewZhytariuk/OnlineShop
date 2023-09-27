using NUnit.Framework;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Tests.ModelsTests
{
    [TestFixture]
    public static class CategoryTests
    {
        [TestCase(1)]
        public static void GivenCategoryWhenAddTwoProductAndRemoveOneProductWithCategoryThemCategoryHAveOneProduct(int count)
        {
            var guid = Guid.NewGuid();
            List<ImageProduct> imageProducts = new List<ImageProduct>();
            Product productOne = new Product(guid, "Iphone", true, new Category(), new Price(), imageProducts);
            Product productTwo = new Product(Guid.NewGuid(), "Android", true, new Category(), new Price(), imageProducts);
            Category category = new Category(guid, "Work", new Item(), productOne);
            category.AddProduct(productTwo);

            category.RemoveProduct(productOne.Id);

            Assert.AreEqual(count, category.Products.Count);
        }
    }
}
