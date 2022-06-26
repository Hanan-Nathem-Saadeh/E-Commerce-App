using FastMarket.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface ICart
    {

        // method to get all Carts
        Task<List<CartDTO>> GetCarts();
        // method to get specific cart by id

        Task<Cart> GetCart(int id);

        // method to create new Carts

        Task<Cart> Create(Cart cart);
        // method to update a Cart

        Task<Cart> UpdateCart(int id, Cart cart);
        // method to delete a Cart

        Task Delete(int id);



        Task<Cart> AddProductToCart(int CartId, Product product);

        Task deleteProductFromCart(int CartId, int productId);

    }
}
