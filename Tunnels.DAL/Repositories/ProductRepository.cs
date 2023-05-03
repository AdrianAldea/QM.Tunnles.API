using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tunnels.Core.Models;
using Tunnels.Core.Repositories;

namespace Tunnels.DAL.Repositories {
    public class ProductRepository : Repository<Product>, IProductRepository {
        public ProductRepository(TunnelsDbContext context)
            : base(context) {
        }

        public async Task<List<Product>> GetAllProductsAsync(bool? isActive) {
            if (isActive == null) {
                return await TunnelsDbContext.Products.ToListAsync();
            }
            else {
                return await TunnelsDbContext.Products.Where(x => x.IsActive == isActive).ToListAsync();
            }
        }

        public async Task DeleteById(int id) {
            var product = await TunnelsDbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            product.IsActive = false;
            TunnelsDbContext.Products.Update(product);
            await TunnelsDbContext.SaveChangesAsync();
        }

        private TunnelsDbContext TunnelsDbContext => Context as TunnelsDbContext;
    }
}
