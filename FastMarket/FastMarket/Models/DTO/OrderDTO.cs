using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.DTO
{
    public class OrderDTO
    {
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }
        public string Address { get; set; }
        public DateTime? datetime { get; set; }
        public string UserID { get; set; }
        public string OrderListJSON { get; set; }


    }

}
