using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FastMarket.Data;
using FastMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FastMarketTestData
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly FastMarketDBContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new FastMarketDBContext(
                new DbContextOptionsBuilder<FastMarketDBContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }


        protected async Task<Categories> CreateAndSaveTestCategory()
        {
            var category = new Categories { Id = 1, Name = "CategoryTest1", Details = "very good" };
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, category.Id);
            return category;
        }
        protected async Task<Product> CreateAndSaveTestProduct()
        {
            var Product = new Product { Id = 1, Name = "NTest1", Price = 100, Amount = 200, Description = "Good", ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            _db.Products.Add(Product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, Product.Id);
            return Product;
        }
        //[Fact]
        //protected async Task<Product> listProductData() {

        //    //List<Product> listData = new List<Product>() {
        //    //    new Product { Id = 2, Name = "Blushes", Price = 20.00m, Description = "URBANMAC Premium Synthetic Kabuki Foundation Face Powder Blush Eyeshadow Brush Makeup Brush Kit with Blender Sponge and Brush Cleaner - Makeup Brushes Set", Amount = 120, },
        //    //    new Product { Id = 3, Name = "Foundation ", Price = 50.00m, Description = "Coloressence Full Coverage Waterproof Lightweight Matte Formula Opaque Lotion High Definition Foundation (HDF-2) with Set of 2 Blending Sponge", Amount = 250, },
        //    //    new Product { Id = 4, Name = "Concealer ", Price = 35.00m, Description = "Wiffy Concealer Base Palette 15 In 1 Cream Kit Concealer", Amount = 60 },
        //    //    new Product { Id = 5, Name = "Product1", Amount = 30, Description = "Description1", Price = 100 },
        //    //    new Product { Id = 6, Name = "Product2", Amount = 40, Description = "Description2", Price = 350 },
        //    //    new Product { Id = 7, Name = "Product3", Amount = 50, Description = "Description3", Price = 200 },
        //    //    new Product { Id = 8, Name = "Product4", Amount = 60, Description = "Description4", Price = 230 },
        //    //    new Product { Id = 9, Name = "Product5", Amount = 70, Description = "Description5", Price = 105 },
        //    //    new Product { Id = 10, Name = "Product10", Amount = 70, Description = "Description10", Price = 105 }


        //    //};
        //    //foreach (var item in listData)
        //    //{

        //    //}
        //    Product product = new Product {  Name = "Liner & Colossal Kajal", Price = 15.5m, Description = "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", Amount = 150, };
        //     _db.Products.Add(product);
        //    await _db.SaveChangesAsync();
        //    Assert.NotEqual(0, product.Id);
        //    return product;
        //}
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

    }
}