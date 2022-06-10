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
            return new CategoriesServices(_db,_configration);
        }
       


        //Lab 27 Test the CRUD capabilities of your controllers
         //1- Test Create method
        [Fact]
        public async void  UpdateTest()
        {
            Categories category = new Categories { Id = 1, Name = "Test1", Details = "GOOD" };
            var service = CategoryService(_configration);
            Categories newCategory = new Categories { Id = 1, Name = "Test2", Details = "GOOD" };
            var result = await service.UpdateCategories(1, newCategory);
            Assert.Equal("Test2", result.Name);
        }
    }
}
