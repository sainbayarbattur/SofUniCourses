namespace BookShop
{
    using BookShop.Initializer;
    using Data;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                string input = Console.ReadLine();

                Console.WriteLine(GetBooksReleasedBefore(db, input));
            }
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var result = new StringBuilder();

            var books = context.Books
                .Select(b => new { b.Title, b.Price, Type = b.EditionType.ToString(), b.ReleaseDate })
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} - {book.Type} - ${book.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
