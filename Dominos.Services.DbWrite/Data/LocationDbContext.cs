using Dominos.Services.DbWrite.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dominos.Services.DbWrite.Data
{
    public class LocationDbContext:DbContext
    {
        public LocationDbContext(DbContextOptions<LocationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Location> Locations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(sensitiveDataLoggingEnabled: true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasIndex(e => e.id).IsUnique();
                entity.Property(e => e.src_long).HasColumnType("float").IsRequired();
                entity.Property(e => e.src_lat).HasColumnType("float").IsRequired();
                entity.Property(e => e.des_long).HasColumnType("float").IsRequired();
                entity.Property(e => e.des_lat).HasColumnType("float").IsRequired();
            });

        }
    }
}
