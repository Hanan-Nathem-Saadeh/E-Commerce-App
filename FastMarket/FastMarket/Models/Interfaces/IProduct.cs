using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface  IProduct
    {        
        // method to get all products

        Task<List<Product>> GetProducts();
        // method to get specific products by id

        Task<Product> GetProduct(int id);
        // method to create new products

        Task<Product> Create(Product product,IFormFile file);
        // method to update a products
        Task<Product> UpdateProduct(int id, Product product, IFormFile file);
        // method to Delete a products

        Task Delete(int id);

        // check if the amout that user requer of some product is out of range or not
        Task<bool> checkAmount(Product product );

    }
}
