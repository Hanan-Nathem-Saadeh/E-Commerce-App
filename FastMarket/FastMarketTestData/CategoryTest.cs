using FastMarket.Models;
using FastMarket.Models.Interfaces;
using FastMarket.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FastMarketTestData
{
    public class CategoryTest :Mock
    {
        IConfiguration _configration;
        private ICategories CategoryService(IConfiguration configuration)
        {
            _configration = configuration;
            return new CategoriesServices(_db,_configration);
        }
        //Lab 27 Test the CRUD capabilities of your controllers
        //1- Test Create method
        [Fact]
        protected async void createandsavetestcategory()
        {
            var category = new Categories { Id = 7, Name = "categorytest1", Details = "very good" };
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, category.Id);
        }

        
        //2- Test Update method
        [Fact]
        public async void  UpdateCategory()
        {
            Categories category = new Categories { Id = 7, Name = "Test1", Details = "GOOD" };
            var service = CategoryService(_configration);
            await service.Create(category);
            category.Name = "TestUpdate";
            var result = await service.UpdateCategories(7, category);
            Assert.Equal("TestUpdate", result.Name);
        }
        // 3- Test Delete Category
        [Fact]
        public async void DeleteCategory()
        {
            Categories category = new Categories { Id = 7, Name = "Test1", Details = "GOOD" };
            var service = CategoryService(_configration);
            await service.Create(category);
            List<Categories> c1 = await service.GetCategories();
            Assert.Equal(7, c1.Count);
            await service.Delete(7);
            int Id = category.Id;
            List<Categories> c2 = await service.GetCategories();
            Assert.Equal(6, c2.Count);
        }
        // 4- Test Get one Category
        [Fact]
        public async void GetCategoryById()
        {
            // new Categories { Id = 6, Name = "Furniture", Details = "Furniture Category contain multiple product like Beds ,Beds Covers, Sofa" }
            var service = CategoryService(_configration);
           var c1 = await service.GetCategory(6);
            
            Assert.Equal(6, c1.Id);
            Assert.Equal("Furniture", c1.Name);
        }
        // 5- Test Get all categories
        [Fact]
        public async void GetCategories()
        {
           var service = CategoryService(_configration);
            List<Categories> c1 = await service.GetCategories();
            Assert.Equal(6, c1.Count); // becuase we have 6 category in seed data
        }
      
    }
}
