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


        Task<Cart> Create(Cart cart);
        Task<Cart> UpdateCart(int id, Cart cart);
        Task Delete(int id);



        Task<Cart> AddProductToCart(int CartId, Product product);

        Task deleteProductFromCart(int CartId, int productId);

    }
}
