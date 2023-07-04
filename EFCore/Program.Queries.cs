using Microsoft.EntityFrameworkCore;
using EFCore.Shared;


partial class Program
{
    static void GetCategories()
    {
        using (Northwind db = new())
        {
            SectionTitle("Liste des catégories");

            IQueryable<Category>? categories = db.Categories?
                .TagWith("GetCategories")
                .Include(c => c.Products);

            Info($"ToQueryString: {categories?.ToQueryString()}");
            if ((categories is null) || (!categories.Any()))
            {
                Fail("Aucune catégorie trouvée");
                return;
            }

            foreach (Category c in categories)
            {
                WriteLine($"{c.CategoryName} possede {c.Products.Count} produits");
            }
        }
    }

    // static void FilteredIncludes()
    // {
    //     using (Northwind db = new())
    //     {
    //         SectionTitle("Products with a minimum number of units instock.");
    //         string? input;
    //         int stock; do
    //         {
    //             Write("Enter a minimum for units in stock: ");
    //             input = ReadLine();
    //         } while (!int.TryParse(input, out stock));
    //         IQueryable<Category>? categories = db.Categories?
    //           .Include(c => c.Products.Where(p => p. >= stock));
    //         if ((categories is null) || (!categories.Any()))
    //         {
    //             Fail("No categories found.");
    //             return;
    //         }
    //         foreach (Category c in categories)
    //         {
    //             WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
    //             foreach (Product p in c.Products)
    //             {
    //                 WriteLine($"  {p.ProductName} has {p.Stock} units instock.");
    //             }
    //         }
    //     }
    // }
}