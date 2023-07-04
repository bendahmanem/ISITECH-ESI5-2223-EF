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
                .Include(c => c.Products);

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
}