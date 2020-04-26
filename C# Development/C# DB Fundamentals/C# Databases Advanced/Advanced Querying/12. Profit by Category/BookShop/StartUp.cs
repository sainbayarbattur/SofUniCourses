namespace BookShop
{
    using BookShop.Initializer;
    using Data;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                System.Console.Write(GetTotalProfitByCategory(db));
            }
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = new StringBuilder();

            var categories = context.Categories
                .Select(c => new { c.Name, Sum = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies) })
                .OrderBy(c => c.Name)
                .OrderByDescending(c => c.Sum)
                .Select(c => new { Format = c.Name + " $" + c.Sum })
                .ToList();

            foreach (var category in categories)
            {
                result.AppendLine(category.Format);
            }

            return result.ToString();
        }
    }
}
