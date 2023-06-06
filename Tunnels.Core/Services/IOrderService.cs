using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Views;

namespace Tunnels.Core.Services {
    public interface IOrderService {
        Task<List<OrdersWithProductsView>> GetAllOrdersWithProductsByFilterAsync(OrdersWithProductsFilterRequest ordersWithProductsFilter);
        Task<Order> CreateOrder(Order order);
        Task InvalidateOrder(int orderId);
    }
}
