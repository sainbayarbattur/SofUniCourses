namespace BookShop
{
    using Data;
    using System.Text;
    using System.Linq;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                Console.WriteLine(GetGoldenBooks(db));
            }
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var result = new StringBuilder();

            var bookTitles = context.Books
                .Select(b => new { b.Title, b.EditionType, b.BookId, b.Copies })
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToList();

            foreach (var bookTitle in bookTitles)
            {
                result.AppendLine(bookTitle.Title);
            }

            return result.ToString();
        }
    }
}
