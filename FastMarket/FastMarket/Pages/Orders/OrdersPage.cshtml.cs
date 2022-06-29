using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMarket.Models;
using FastMarket.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FastMarket.Pages.Orders
{
    public class OrdersPageModel : PageModel
    {
        private readonly IOrder _order;

        public OrdersPageModel(IOrder  order)
        {
            this._order = order;
        }
        [BindProperty]
        public List<Categories> list1 { get; set; }


        [BindProperty]
        public List<Order> Orders { get; set; }

        [BindProperty]
        public List<Product> ListProduct { get; set; }

        public async Task OnGet(string userId)
        {
            if (userId== null) { Orders = await _order.GetOrders();

                ViewData["viewUserID"] = "user";
            } else { 
                Orders = await _order.GetOrderByUserID(userId); }
            
                
                
        
        }
    
    }
}
