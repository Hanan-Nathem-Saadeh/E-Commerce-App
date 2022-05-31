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
        Task<Cart> UpdateCategories(int id, Categories categories);
        Task Delete(int id);


        Task<Categories> AddProductToCategories(int categoriesId, Product product);
        
        Task deleteProductFromCategories(int categoriesId, int productId);
    }
}
