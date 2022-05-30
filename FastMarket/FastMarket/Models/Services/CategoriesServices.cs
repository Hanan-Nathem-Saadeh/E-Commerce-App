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

        public async Task<List<Categories>> GetCategories()
        {
            return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).ToListAsync();
        }

        public async Task<Categories> GetCategory(int id)
        {
             return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).FirstOrDefaultAsync(z => z.Id == id);
        }
    }
}
