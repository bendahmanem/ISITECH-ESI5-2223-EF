namespace EFCore.Shared;
using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = "";

    [Column(TypeName = "ntext")]
    public string Description { get; set; } = "";

    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
