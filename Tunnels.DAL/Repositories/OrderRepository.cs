using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Repositories;

namespace Tunnels.DAL.Repositories {
    public class OrderRepository : Repository<Order>, IOrderRepository {

        private TunnelsDbContext TunnelsDbContext => Context as TunnelsDbContext;

        public OrderRepository(TunnelsDbContext context)
            : base(context) { }

        public async Task<List<Order>> GetAllOrdersWithProductsByFilterAsync(OrdersWithProductsFilterRequest ordersWithProductsFilter) {
            Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Order, User> result = null;
            List<Order> orders = new List<Order>();
            switch (ordersWithProductsFilter.FilterType) {
                case FilterTypeEnum.NoFilter:
                    if (ordersWithProductsFilter.IsActive == null) {
                        orders = await TunnelsDbContext.Orders.Include(p => p.ProductsEntries).ThenInclude(x => x.Product)
                            .Include(u => u.User).ToListAsync();
                    }
                    else {
                        orders = await TunnelsDbContext.Orders.Include(p => p.ProductsEntries
                        .Where(x => x.Product.IsActive == ordersWithProductsFilter.IsActive))
                            .ThenInclude(x => x.Product).Include(u => u.User).ToListAsync();
                    }
                    break;
                case FilterTypeEnum.ByDate:

                    if (ordersWithProductsFilter.StartDate == ordersWithProductsFilter.EndDate) {
                        ordersWithProductsFilter.EndDate = ordersWithProductsFilter.EndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    }
                    if (ordersWithProductsFilter.IsActive == null) {
                        result = TunnelsDbContext.Orders
                            .Include(p => p.ProductsEntries
                                .Where(x => x.DateAdded >= ordersWithProductsFilter.StartDate && x.DateAdded <= ordersWithProductsFilter.EndDate))
                            .ThenInclude(x => x.Product).Include(u => u.User);
                    }
                    else {
                        result = TunnelsDbContext.Orders
                            .Include(p => p.ProductsEntries
                                .Where(x => x.DateAdded >= ordersWithProductsFilter.StartDate && x.DateAdded <= ordersWithProductsFilter.EndDate)
                                .Where(x => x.Product.IsActive == ordersWithProductsFilter.IsActive))
                            .ThenInclude(x => x.Product).Include(u => u.User);
                    }

                    orders = await result.ToListAsync();
                    break;
                case FilterTypeEnum.ByOrderId:
                    if (ordersWithProductsFilter.IsActive == null) {
                        orders = await TunnelsDbContext.Orders.Include(p => p.ProductsEntries)
                        .ThenInclude(x => x.Product).Include(u => u.User)
                        .Where(x => x.Id == ordersWithProductsFilter.OrderId)
                        .ToListAsync();
                    }
                    else {
                        orders = await TunnelsDbContext.Orders.Include(p => p.ProductsEntries.Where(x => x.Product.IsActive == ordersWithProductsFilter.IsActive))
                        .ThenInclude(x => x.Product).Include(u => u.User)
                        .Where(x => x.Id == ordersWithProductsFilter.OrderId)
                        .ToListAsync();
                    }
                    break;
                case FilterTypeEnum.ByProductId:
                    if (ordersWithProductsFilter.IsActive == null) {
                        orders = await TunnelsDbContext.Orders
                         .Include(p => p.ProductsEntries.Where(x => x.ProductId == ordersWithProductsFilter.ProductId))
                         .ThenInclude(x => x.Product).Include(u => u.User)
                         .ToListAsync();
                    }
                    else {
                        orders = await TunnelsDbContext.Orders
                        .Include(p => p.ProductsEntries.Where(x => x.ProductId == ordersWithProductsFilter.ProductId && x.Product.IsActive == ordersWithProductsFilter.IsActive))
                        .ThenInclude(x => x.Product).Include(u => u.User)
                        .ToListAsync();
                    }
                    break;
                case FilterTypeEnum.ByDateAndProductId:
                    if (ordersWithProductsFilter.StartDate == ordersWithProductsFilter.EndDate) {
                        ordersWithProductsFilter.EndDate = ordersWithProductsFilter.EndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    }

                    Order order = TunnelsDbContext.Orders
                            .Include(p => p.ProductsEntries
                                .Where(x => x.ProductId == ordersWithProductsFilter.ProductId))
                            .ThenInclude(x => x.Product).Include(u => u.User).Select(x => x).FirstOrDefault();
                    orders.Add(order);

                    if (ordersWithProductsFilter.IsActive == null) {
                        result = TunnelsDbContext.Orders
                            .Include(p => p.ProductsEntries
                                .Where(x => x.DateAdded >= ordersWithProductsFilter.StartDate
                                && x.DateAdded <= ordersWithProductsFilter.EndDate && x.ProductId == ordersWithProductsFilter.ProductId))
                            .ThenInclude(x => x.Product).Include(u => u.User);
                    }
                    else {
                        result = TunnelsDbContext.Orders.Where(x => x.OperationType == OperationTypeEnum.IN)
                            .Include(p => p.ProductsEntries
                                .Where(x => x.DateAdded >= ordersWithProductsFilter.StartDate
                                && x.DateAdded <= ordersWithProductsFilter.EndDate && x.ProductId == ordersWithProductsFilter.ProductId)
                                .Where(x => x.Product.IsActive == ordersWithProductsFilter.IsActive))
                            .ThenInclude(x => x.Product).Include(u => u.User);
                    }
                    orders.AddRange(await result.ToListAsync());
                    break;
                default:
                    if (ordersWithProductsFilter.IsActive == null) {
                        return await TunnelsDbContext.Orders.Include(p => p.ProductsEntries).ThenInclude(x => x.Product).Include(u => u.User).ToListAsync();
                    }
                    else {
                        return await TunnelsDbContext.Orders.Include(p => p.ProductsEntries.Where(x => x.Product.IsActive == ordersWithProductsFilter.IsActive)).ThenInclude(x => x.Product).Include(u => u.User).ToListAsync();
                    }
            }

            if (ordersWithProductsFilter.OperationType != OperationTypeEnum.ALL) {
                orders = orders.Where(x => x.OperationType == ordersWithProductsFilter.OperationType).ToList();
            }
            if (ordersWithProductsFilter.IsOrderActive != null) {
                orders = orders.Where(x => x.IsActive == ordersWithProductsFilter.IsOrderActive).ToList();
            }

            return orders;
        }

        public async Task<Order> CreateOrder(Order order) {
            foreach (var productEntry in order.ProductsEntries) {
                if (productEntry.ProductId == 0) { // Add product
                    TunnelsDbContext.Entry<Product>(productEntry.Product).State = EntityState.Added;
                }
                else { // Update Product
                    var product = await TunnelsDbContext.Products.FirstOrDefaultAsync(p => p.Id == productEntry.ProductId);
                    product.CurrentQuantity = product.CurrentQuantity - productEntry.Product.CurrentQuantity;
                    product.CurrentValue = product.CurrentQuantity * product.BuyPrice;
                    if (product.CurrentQuantity == 0) {
                        product.IsActive = false;
                    }
                    productEntry.Product = product;
                }
            }

            var result = await TunnelsDbContext.Orders.AddAsync(order);
            return result.Entity;
        }

        public async Task InvalidateOrder(int orderId) {
            var order = await TunnelsDbContext.Orders.FirstOrDefaultAsync(p => p.Id == orderId);
            if (order != null) {
                order.IsActive = false;
                var result = TunnelsDbContext.Orders.Update(order);
            }

        }
    }
}
