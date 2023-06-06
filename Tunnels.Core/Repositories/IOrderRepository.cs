using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;

namespace Tunnels.Core.Repositories {
    public interface IOrderRepository {
        Task<List<Order>> GetAllOrdersWithProductsByFilterAsync(OrdersWithProductsFilterRequest ordersWithProductsFilter);
        Task<Order> CreateOrder(Order order);
        Task InvalidateOrder(int orderId);
    }
}
