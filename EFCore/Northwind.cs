using Microsoft.EntityFrameworkCore;
namespace EFCore.Shared;

public class Northwind : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(
            Environment.CurrentDirectory, "Northwind.db");

        string connection = $"Filename={path}";

        ConsoleColor color = Console.ForegroundColor;
        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine($"Connection string: {connection}");
        ForegroundColor = color;

        optionsBuilder.UseSqlite(connection);
        // optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Exemple d'usage de la FLUENT API pour configurer des champs
        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(15);
        if (Database.ProviderName.Contains("Sqlite"))
        {
            // Permet de palier a l'absence de support pour le type decimal en SQLite
            modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasConversion<double>();
        }

    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product>? Products { get; set; }

}