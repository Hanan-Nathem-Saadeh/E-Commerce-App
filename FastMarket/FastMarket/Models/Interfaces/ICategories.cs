using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface ICategories
    {
        // method to get all Categories

        Task<List<Categories>> GetCategories();
        // method to get specific Category by id

        Task<Categories> GetCategory(int id);
        // method to create new Category

        Task<Categories> Create(Categories categories);
        // method to update a Category

        Task<Categories> UpdateCategories(int id, Categories categories);
        // method to Delete a Category

        Task Delete(int id);

        // method to add a product to Category

        Task<Product> AddProductToCategories(int categoriesId, Product product, IFormFile file);
        // method to remove product from Category

        Task deleteProductFromCategories(int categoriesId, int productId);
    }
}
