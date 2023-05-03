using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunnels.Core.Models;

namespace Tunnels.DAL.Configurations {
    public class OrderConfiguration {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder
                .HasKey(a => a.Id);

            builder
                .ToTable("Orders");
        }
    }
}
