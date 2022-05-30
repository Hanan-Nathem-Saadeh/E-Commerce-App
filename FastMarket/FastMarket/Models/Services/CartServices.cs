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


    }
}
