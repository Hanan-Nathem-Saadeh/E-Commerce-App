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
        // method to get all Carts

        public async Task<List<CartDTO>> GetCarts()
        {
            return await _context.Carts.Select(
                
                cart => new CartDTO { 
                
                UserId = cart.UserId,
                totalPrice = cart.totalPrice
                
                }).ToListAsync();
        }
        // method to get specific cart by id

        public async Task<Cart> GetCart(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x=> x.Id == id);
        }
        // method to create new Carts

        public async Task<Cart> Create(Cart cart)
        {


            _context.Entry(cart).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return cart;
        }
        // method to update a Cart

        public Task<Cart> UpdateCart(int id, Cart cart)
        {
            throw new NotImplementedException();
        }
        // method to delete a Cart

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
