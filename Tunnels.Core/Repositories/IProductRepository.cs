using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;

namespace Tunnels.Core.Repositories {
    public interface IProductRepository : IRepository<Product> {
        Task<List<Product>> GetAllProductsAsync(bool? isActive);
        Task DeleteById(int id);
    }
}