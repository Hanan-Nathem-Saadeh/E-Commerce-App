using FastMarket.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface ICart
    {


        Task<List<CartDTO>> GetCarts();
        Task<Cart> GetCart(int id);
    }
}
