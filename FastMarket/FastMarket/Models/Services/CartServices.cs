using FastMarket.Data;
using FastMarket.Models.DTO;
using FastMarket.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class CartServices : ICart
    {
        private readonly FastMarketDBContext _context;

        public CartServices(FastMarketDBContext context)
        {
            _context = context;
        }

        public async Task<List<CartDTO>> GetCarts()
        {
            return await _context.Carts.Select(
                
                cart => new CartDTO { 
                
                UserId = cart.UserId,
                totalPrice = cart.totalPrice
                
                }).ToListAsync();
        }

        public async Task<Cart> GetCart(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Cart> Create(Cart cart)
        {


            _context.Entry(cart).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return cart;
        }

        public Task<Cart> UpdateCart(int id, Cart cart)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
            if (cart != null)
            {
                _context.Entry(cart).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public Task<Cart> AddProductToCart(int CartId, Product product)
        {
            throw new NotImplementedException();
        }

        public Task deleteProductFromCart(int CartId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
