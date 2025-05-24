using Microsoft.EntityFrameworkCore;
using ParkingLotRental.Domain.Entities;
using System.Reflection;

namespace ParkingLotRental.Infrastructure.Persistence.DbContexts
{
    public class ParkingLotRentalDbContext : DbContext
    {
        public ParkingLotRentalDbContext(DbContextOptions<ParkingLotRentalDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // This line is optional if you prefer to configure entities here

            // Example of fluent API configuration (can also be in separate IEntityTypeConfiguration classes)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Address).IsRequired().HasMaxLength(500);
                entity.Property(e => e.City).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
                entity.Property(e => e.HourlyRate).HasColumnType("decimal(18,2)");
                entity.HasOne<User>() // Assuming a ParkingLot is owned by a User
                       .WithMany() // Assuming a User can own multiple ParkingLots (configure inverse navigation if needed in User)
                       .HasForeignKey(p => p.OwnerId)
                       .IsRequired();
                entity.HasMany(p => p.Reservations)
                      .WithOne() // Assuming a Reservation is for one ParkingLot
                      .HasForeignKey(r => r.ParkingLotId)
                      .IsRequired();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TotalCost).HasColumnType("decimal(18,2)");
                entity.HasOne<User>() // Assuming a Reservation is made by a User
                       .WithMany() // Assuming a User can have multiple Reservations (configure inverse navigation if needed in User)
                       .HasForeignKey(r => r.UserId)
                       .IsRequired();
                // The relationship with ParkingLot is already defined in ParkingLot entity configuration
            });
        }
    }
}
