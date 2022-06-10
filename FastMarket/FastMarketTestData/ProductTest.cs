using FastMarket.Models;
using FastMarket.Models.Services;
using System;
using Xunit;

namespace FastMarketTestData
{
    public class ProductTest : Mock
    {
        // [Fact]
        //public async void TestUpdatingProduct()
        //{
        //    Product product = (Product)CreateAndSaveTestProduct().Result;
        //    int OldProductAmount = product.Amount;
        //    product.Amount = 100;
        //    var productService = new ProductService(_db,_configration);
        //    IFormFile file="";
        //    product = await productService.UpdateProduct(product.Id, product, file);
        //    product = productService.GetProduct(course.Id).Result;
        //    Assert.NotEqual(OldCourseCode, course.CourseCode);
        //}
        //protected async Task<Product> CreateAndSaveTestProduct()
        //{
        //    var Product = new Product { Id = 1, Name = "NTest1", Price = 100, Amount = 200, Description = "Good", ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png")};
        //    _db.Products.Add(Product);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, Product.Id);
        //    return Product;
        //}
        //[Fact]
        //public async void Test1()
        //{
        //    var repo = new ProductService(_db);

        //    Product product = listProductData().Result;

        //    Assert.NotEqual(0,product.Id);

        //}

        //[Fact]
        //public async void Test2()
        //{
        //    var repo = new ProductService(_db);

        //    Product product = listProductData().Result;
        //    Product product2 = repo.GetProduct(product.Id).Result;

        //   Assert.Equal(product.Name  ,product2.Name );

        //}
    }
}
