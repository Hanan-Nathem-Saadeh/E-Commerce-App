using FastMarket.Data;
using FastMarket.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class CategoriesServices : ICategories
    {

        private readonly FastMarketDBContext _context;

        public CategoriesServices(FastMarketDBContext context)
        {
            _context = context;
        }

        public Task<Categories> AddProductToCategories(int categoriesId, Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Categories> Create(Categories categories)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            Categories categories= await _context.Categories.FirstOrDefaultAsync(z => z.Id == id);

            if (categories != null)
            {
                _context.Entry(categories).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public Task deleteProductFromCategories(int categoriesId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Categories>> GetCategories()
        {
            return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).ToListAsync();
        }

        public async Task<Categories> GetCategory(int id)
        {
             return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).FirstOrDefaultAsync(z => z.Id == id);
        }

        public Task<Cart> UpdateCategories(int id, Categories categories)
        {
            throw new NotImplementedException();
        }
    }
}
