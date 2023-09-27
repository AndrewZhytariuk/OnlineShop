using NUnit.Framework;
using OnlineShop.CategoryData.Models;

namespace OnlineShop.CategoryData.Tests.ModelsTests
{
    [TestFixture]
    public static class ProduuctTests
    {
        [TestCase(1)]
        public static void GivenProductWhenAddImageAndRemoveImageWithProductIsentHaveImage(int count)
        {
            var guid = Guid.NewGuid();
            List<ImageProduct> imageOne = new List<ImageProduct> { new ImageProduct (guid, new Product(), "http://image1.png") };
            ImageProduct imageTwo = new ImageProduct(Guid.NewGuid(), new Product(), "http://image2.png");
            Product product = new Product(guid, "Iphone is new", true, new Category(), new Price(), imageOne);
            product.AddImages(imageTwo);

            product.RemoveImage(imageTwo.Id);

            Assert.AreEqual(count, product.Images.Count);
        }
    }
}
