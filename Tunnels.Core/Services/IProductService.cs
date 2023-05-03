using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core.Models;

namespace Tunnels.Core.Services {
    public interface IProductService {
        Task DeleteById(int id);
        Task<IEnumerable<Product>> GetAllProducts(bool? isActive);
    }
}
