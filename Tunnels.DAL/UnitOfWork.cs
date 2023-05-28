using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tunnels.Core;
using Tunnels.Core.Models;
using Tunnels.Core.Repositories;
using Tunnels.DAL.Repositories;

namespace Tunnels.DAL {
    public class UnitOfWork : IUnitOfWork {
        private readonly TunnelsDbContext _context;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(TunnelsDbContext context) {
            _context = context;
            //_context.Database.EnsureDeleted(); // TODO: DELETE IN PRODUCTION AFTER MIGRATIONS IMPLEMENTATION, EnsureDeleted DELETE DB IF EXISTS
            //_context.Database.EnsureCreated();
            AddAdminUser();
        }

        private async void AddAdminUser() {
            if (this.Users.GetAllUsers().Result.Count == 0) {
                await this.Users.AddAsync(new User {
                    DateAdded = DateTime.Now,
                    Email = "suntadrian@gmail.com",
                    Name = "System Administrator",
                    Password = "123123",
                    Role = RolesEnum.Administrator,
                    Username = "sa"
                });
                await this.CommitAsync();
            }
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);


        public async Task<int> CommitAsync() {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
