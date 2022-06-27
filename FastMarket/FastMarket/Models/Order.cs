using System;
using System.Collections.Generic;

namespace FastMarket.Models
{
    // Order Model
    public class Order
    {
        public int Id { get; set; }
        public string UserID {  get; set; }
         public int TotalPrice {get; set; }
        public int Count { get; set; }
        public string Address { get; set; }
        public DateTime? datetime = DateTime.UtcNow;
        public List<Product> OrderList { get; set; }
    }
}
