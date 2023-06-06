using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core;
using Tunnels.Core.Mappers;
using Tunnels.Core.Models;
using Tunnels.Core.Services;
using Tunnels.Core.Views;

namespace Tunnels.Services {
    public class OrderService : IOrderService {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order order) {

            var orderCreated = await _unitOfWork.Orders.CreateOrder(order);
            await _unitOfWork.CommitAsync();
            return orderCreated;
        }

        public async Task InvalidateOrder(int orderId) {

            await _unitOfWork.Orders.InvalidateOrder(orderId);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<OrdersWithProductsView>> GetAllOrdersWithProductsByFilterAsync(OrdersWithProductsFilterRequest ordersWithProductsFilter) {
            var orders = await _unitOfWork.Orders.GetAllOrdersWithProductsByFilterAsync(ordersWithProductsFilter);
            var ordersView = OrdersWithProductsMapper.Map(orders);
            return ordersView;
        }
    }
}
