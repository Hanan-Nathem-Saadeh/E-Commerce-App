using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface ICategories
    {

        Task<List<Categories>> GetCategories();
        Task<Categories> GetCategory(int id);

        Task<Categories> Create(Categories categories);
        Task<Categories> UpdateCategories(int id, Categories categories);
        Task Delete(int id);


        Task<Product> AddProductToCategories(int categoriesId, Product product, IFormFile file);
        
        Task deleteProductFromCategories(int categoriesId, int productId);
    }
}
