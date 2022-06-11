using FastMarket.Models;
using FastMarket.Models.Interfaces;
using FastMarket.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace FastMarketTestData
{
    public class ProductTest : Mock
    {

        IConfiguration _configration;
        private IProduct ProductService(IConfiguration configuration)
        {
            _configration = configuration;
            return new ProductService(_db, _configration);
        }
        //Lab 27 Test the CRUD capabilities of your controllers
        //1- Test Create method
        [Fact]
        protected async void createandsavetestProduct()
        {
            var service = ProductService(_configration);
            List<Product> list = await service.GetProducts();
            Assert.Equal(10,list.Count);
            var newproduct = new Product { Id = 11, Name = "NTest1", Price = 100, Amount = 200, Description = "Good", ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            _db.Products.Add(newproduct);
            await _db.SaveChangesAsync();
            List<Product> list2 = await service.GetProducts();
            Assert.Equal(11, list2.Count);
        }


        //2- Test Update method
        [Fact]
        public async void UpdateProduct()
        {
            Product newproduct = new Product { Id=30, Name = "NTest1", Price = 100, Amount = 200, Description = "Good", ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };

            var service = ProductService(_configration);
            await service.Create(newproduct, null);
            newproduct.Name = "TestUpdateMethod";
            var result = await service.UpdateProduct(newproduct.Id,  newproduct,null);       
            Assert.Equal("TestUpdateMethod", result.Name);
        }
        // 3- Test Delete product
       [Fact]
        public async void DeleteProduct()
        {
            Product product = new Product { Id = 11, Name = "NTest1", Price = 100, Amount = 200, Description = "Good", ImageUri = new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png") };
            var service = ProductService(_configration);
            await service.Create(product,null);
            List<Product> p1 = await service.GetProducts();
         Assert.Equal(11, p1.Count);
           await service.Delete(product.Id);
           List<Product> p2 = await service.GetProducts();
           Assert.Equal(10, p2.Count);
        }
       // 4- Test Get one product
       [Fact]
        public async void GetProductById()
        {
            //  new Product { Id = 1, Name = "Liner & Colossal Kajal", Price = 15.5m, Description = "Maybelline New York Colossal Bold Liner & Colossal Kajal - EYE KIT COMBO (Pack Of 2), 0.35 gm + 3 ml", Amount = 150, ImageUri= new Uri("https://faststorestorage.blob.core.windows.net/images/DefaultIMG.png")},
            var service = ProductService(_configration);
            var c1 = await service.GetProduct(1);

            Assert.Equal(1, c1.Id);
            Assert.Equal("Liner & Colossal Kajal", c1.Name);
        }
        // 5- Test Get all Product
         [Fact]
        public async void GetProducts()
        {
            var service = ProductService(_configration);
            List<Product> c1 = await service.GetProducts();
            Assert.Equal(10, c1.Count); // becuase we have 10 products in seed data
        }
           }
}
