using FastMarket.Data;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class CategoriesServices : ICategories
    {

        private readonly FastMarketDBContext _context;
        IConfiguration _configration;

        public CategoriesServices(FastMarketDBContext context , IConfiguration configration)
        {
            _context = context;
            _configration = configration;
        }

        public async Task<Product> AddProductToCategories(int categoriesId, Product product,IFormFile file)
        {
            ProductService PService = new ProductService(_context,_configration);
            product.ImageUri=  PService.GetFile(file).Result;
            _context.Entry(product).State = EntityState.Added;

            await _context.SaveChangesAsync();
            //product = await _context.Products.FirstOrDefaultAsync();
            CategoriesProduct categoryProduct = new CategoriesProduct()
            {
                ProductId = product.Id,
                CategoriesId = categoriesId
            };

            _context.Entry(categoryProduct).State = EntityState.Added;

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Categories> Create(Categories categories)
        {
            _context.Entry(categories).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return categories;
        }

        public async Task Delete(int id)
        {
         

            Categories categories = await _context.Categories.FindAsync(id);

            
                _context.Entry(categories).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
           
           
        }

        public async Task deleteProductFromCategories(int categoriesId, int productId)
        {
            //CategoriesProduct categories = await _context.CategoriesProducts.FirstOrDefaultAsync(x => x.ProductId == productId && x.CategoriesId==categoriesId);
            Product categories = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (categories != null)
            {
                _context.Entry(categories).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Categories>> GetCategories()
        {
            return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).ToListAsync();
        }

        public async Task<Categories> GetCategory(int id)
        {
             return await _context.Categories.Include(x => x.categoriesProducts).ThenInclude(y => y.Product).FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<Categories> UpdateCategories(int id, Categories categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categories;
        }
    }
}
