using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    //Author Seb
    public class SeedCategories
    {
        public static Category[] GetCategories()
        {
            return new[] 
            {
                new Category { Id = 1, EstateCategory = "Villa"},
                new Category { Id = 2, EstateCategory = "Bostadsrättsradhus"},
                new Category { Id = 3, EstateCategory = "Fritidshus"},
                new Category { Id = 4, EstateCategory = "Bostadsrättslägenhet"}
            };
        }
    }
}
