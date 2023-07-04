namespace EFCore.Shared;
using System.ComponentModel.DataAnnotations; // [Required] [StringLength]
using System.ComponentModel.DataAnnotations.Schema;  // [Column]

public class Product
{
    public int ProductId { get; set; } // PK

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = "";

    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; } // Nullable

    // Ici on va definir une FK
    public int CategoryId { get; set; } // FK

    // ICI la ppte est marquee virtual, ce qui permet a EFCore de faire du lazy loading
    // EF Core va charger la categorie associee au produit uniquement si on y accede
    public virtual Category Category { get; set; } = null!;
}