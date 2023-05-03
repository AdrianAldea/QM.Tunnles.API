using System.Collections.Generic;
using System.Threading.Tasks;
using Tunnels.Core;
using Tunnels.Core.Models;
using Tunnels.Core.Services;

namespace Tunnels.Services {
    public class ProductService : IProductService {

        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteById(int id) {
            await _unitOfWork.Products.DeleteById(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(bool? isActive) {
            return await _unitOfWork.Products.GetAllProductsAsync(isActive);
        }
    }
}
