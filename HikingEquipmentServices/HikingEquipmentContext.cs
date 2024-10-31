using HikingEquipment.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace HikingEquipment.Services
{
    public class HikingEquipmentContext : DbContext
    {
        public HikingEquipmentContext(DbContextOptions<HikingEquipmentContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .ToTable("Brands");

            modelBuilder.Entity<Equipment>()
                .ToTable("Equipments");

            modelBuilder.Entity<EquipmentType>()
                .ToTable("EquipmentTypes");
        }
    }

}