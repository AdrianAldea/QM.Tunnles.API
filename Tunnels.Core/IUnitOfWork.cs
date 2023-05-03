using Tunnels.Core.Repositories;
using System;
using System.Threading.Tasks;
using Tunnels.Core.Models;

namespace Tunnels.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task<int> CommitAsync();
    }
}
