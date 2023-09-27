using OnlineShop.CategoryData.Models;
using NUnit.Framework;

namespace OnlineShop.CategoryData.Tests.ModelsTests
{
    [TestFixture]
    public static class ItemTests
    {
        [TestCase(2)]
        public static void GivenItemWhenAddNewCategoryThenItemHaveTwoCategorys(int count) {
            Guid id = Guid.NewGuid();
            Category category = new Category(id, "work", new Item(), new Product());
            Item item = new Item();
            item.Create(id, "Work", category, new ImageItem());

            id = Guid.NewGuid();
            item.AddCategory(new Category(id, "Garden", new Item(), new Product()));

            Assert.AreEqual(count, item.Category.Count);
        }

        [TestCase(0, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = false)]
        public static bool GivenItemWhendRemoveCategoryThenReturnItemWithEmpryCategory(int count)
        {
            Guid id = Guid.NewGuid();
            Category category = new Category(id, "work", new Item(), new Product());
            Item item = new Item();
            item.Create(id, "Work", category, new ImageItem());

            item.ReemoveCategory(id);

            return count == item.Category.Count;
        }
    }
}
