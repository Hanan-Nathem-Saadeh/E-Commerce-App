using FastMarket.Data;
using FastMarket.Models.DTO;
using FastMarket.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastMarket.Models.Services
{
    public class OrderService : IOrder
    {
        private readonly FastMarketDBContext _context;
        IConfiguration _configration;

        public OrderService(FastMarketDBContext context, IConfiguration configration)
        {
            _context = context;
            _configration = configration;
        }




       


        // method to create new Order
        public async Task<Order> Create(OrderDTO orderDTO)
        {
            Order order = new Order()
            {

                Address = orderDTO.Address,
                Count = orderDTO.Count,
                TotalPrice = orderDTO.TotalPrice,
                datetime = orderDTO.datetime,
                UserID = orderDTO.UserID,
                OrderListJSON = orderDTO.OrderListJSON



            };


            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }

        // method to get specific order by id

      
        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(z => z.Id == id);
        }
        // method to get all Orders

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders. ToListAsync();
        }
        // method to update order
        public async Task<Order> UpdateOrder(int id, Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }
        //method to delete order
        public async Task Delete(int id)
        {
            Order order = await _context.Orders.FindAsync(id);


            _context.Entry(order).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        // method to get specific order by id
        public async Task<List<Order>> GetOrderByUserID(string UserId)
        {
            return await _context.Orders.Where(use1 => use1.UserID == UserId).OrderByDescending(use1 => use1.datetime).Take(20).ToListAsync();
        }
    }
}
