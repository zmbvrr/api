using Microsoft.EntityFrameworkCore;
namespace TP1.Models;

public class UserContext : DbContext
{
    public UserContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public UserContext(DbContextOptions<UserContext> options): base(options)
    {
            
    }

    public DbSet<User> Users {get; set;}
    public DbSet<Produit> Produits {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=LAPTOP-HM1OHB3G;Database=LaBDD;Trusted_Connection=True;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produit>()
            .HasKey(p => p.id);
        modelBuilder.Entity<User>()
            .HasKey(u => u.id);


        modelBuilder.Entity<Produit>()
            .HasOne<User>(p => p.User)
            .WithMany(u => u.Produits)
            .HasForeignKey(p => p.UserID);
    }


}