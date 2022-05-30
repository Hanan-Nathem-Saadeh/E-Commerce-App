using FastMarket.Data;
using FastMarket.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class ProductService : IProduct
    {

        private readonly FastMarketDBContext _context;

        public ProductService(FastMarketDBContext context)
        {
            _context = context;
        }


        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(z => z.Id == id);
        }
    }
}
