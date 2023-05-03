using System.Collections.Generic;
using Tunnels.Core.Models;
using Tunnels.Core.Views;

namespace Tunnels.Core.Mappers {
    public class OrdersWithProductsMapper {
        public static List<OrdersWithProductsView> Map(List<Order> orders) {
            List<OrdersWithProductsView> ordersWithProductsViews = new List<OrdersWithProductsView>();
            foreach (var order in orders) {
                foreach (var productEntry in order.ProductsEntries) {
                    var orderWithProduct = new OrdersWithProductsView {
                        IsActive = productEntry.Product.IsActive,
                        CreatedByUser = order.User.Name,
                        DateAdded = productEntry.DateAdded,
                        DistributionCompany = productEntry.Product.DistributionCompany,
                        OperationType = order.OperationType,
                        OrderId = order.Id,
                        Price = productEntry.Price,
                        ProductName = productEntry.Product.Name,
                        Quantity = productEntry.Quantity,
                        TotalProduct = productEntry.Total,
                        ProductType = productEntry.Type,
                        TotalOrder = order.Total
                    };
                    ordersWithProductsViews.Add(orderWithProduct);
                }
            }
            return ordersWithProductsViews;
        }
    }
}
