using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using Tunnels.Core.Models;

namespace Tunnels.DAL {
    public class TunnelsDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public TunnelsDbContext(DbContextOptions<TunnelsDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {

            builder.Entity<Order>()
                .HasMany(p => p.ProductsEntries)
                .WithMany(p => p.Orders);

            //builder
            //    .ApplyConfiguration(new UserConfiguration());
            //builder
            //    .ApplyConfiguration(new TeamConfiguration());
            //builder
            //    .ApplyConfiguration(new TeamUserConfiguration());
            //builder
            //    .ApplyConfiguration(new RotaConfiguration());
            //builder
            //    .ApplyConfiguration(new RotaTeamUserConfiguration());
            //builder
            //    .ApplyConfiguration(new SlackConnectionConfiguration());


            //builder.Entity<RotaTeamUser>()
            //    .HasKey(ru => new { ru.RotaId, ru.TeamUserId });
            //builder.Entity<RotaTeamUser>()
            //    .HasOne(r => r.Rota)
            //    .WithMany(rtu => rtu.RotaTeamUsers)
            //    .HasForeignKey(r => r.RotaId);
            //builder.Entity<RotaTeamUser>()
            //    .HasOne(tu => tu.TeamUser)
            //    .WithMany(rtu => rtu.RotaTeamUsers)
            //    .HasForeignKey(t => t.TeamUserId);

            //builder.Entity<Team>()
            //    .HasMany(r => r.Rotas)
            //    .WithOne(t => t.Team)
            //    .HasForeignKey(t => t.TeamId);

            //builder.Entity<SlackConnection>()
            //    .HasMany(t => t.Teams)
            //    .WithOne(sc => sc.SlackConnection)
            //    .HasForeignKey(sc => sc.SlackConnectionId);
        }
    }
}
