using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface  IProduct
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProduct(int id);

        Task<Product> Create(Product product);
        Task<Product> UpdateProduct(int id, Product product);
        Task Delete(int id);
    }
}
