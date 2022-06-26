using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.DTO
{
    public class CartDTO
    {

        //  This is the cart DTO
        public int UserId { get; set; }
        public decimal totalPrice { get; set; }
    }
}
