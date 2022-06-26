using System.Collections.Generic;

namespace FastMarket.Models
{
    // Cart Model
    public class Cart
    {
        public int Id { get; set; }       
        public int UserId { get; set; }
        public decimal totalPrice { get; set; }
        public int count { get; set; }

        public List<CartProduct>  cartProducts{ get; set; }

    }
}
