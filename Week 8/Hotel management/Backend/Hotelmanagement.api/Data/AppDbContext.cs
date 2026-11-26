using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Hotelmanagement.api.Model;


namespace Hotelmanagement.api.Data;

public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
{  }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Hotel> Hotels { get; set; } = null!;
    //* Fluent Api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            //* User Model configuration
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
            entity.Property(u => u.PasswordHash).IsRequired();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u=>u.Role).IsRequired();
        });

        //* Hotel Fluent api Configuration
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(h => h.HotelId);
            entity.Property(h => h.HotelName).IsRequired();
            entity.Property(h => h.HotelMail).IsRequired();
            entity.Property(h => h.HotelAddress).IsRequired();
            entity.Property(h=>h.PhoneNo).IsRequired();
        });
    }
}
