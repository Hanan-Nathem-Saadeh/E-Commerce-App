using FastMarket.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastMarket.Models.Interfaces
{
    public interface IOrder
    {
        // method to get all Orders

        Task<List<Order>> GetOrders();
        // method to get specific Order by id

        Task<Order> GetOrder(int id);
        // method to create new Order

        Task<Order> Create(OrderDTO orderDTO);
        // method to update a Order

        Task<Order> UpdateOrder(int id, Order order);
        // method to Delete a Order

        Task Delete(int id);

        public Task<List<Order>> GetOrderByUserID(string UserId);

    }
}
