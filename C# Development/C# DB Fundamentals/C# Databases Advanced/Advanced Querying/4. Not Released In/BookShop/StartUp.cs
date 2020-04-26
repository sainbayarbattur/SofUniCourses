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
                int year = int.Parse(Console.ReadLine());

                Console.Write(GetBooksNotReleasedIn(db, year));
            }
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = new StringBuilder();

            var bookTitles = context.Books
                .Select(b => new { b.Title, b.ReleaseDate, b.BookId })
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var bookTitle in bookTitles)
            {
                result.AppendLine(bookTitle.Title);
            }

            return result.ToString();
        }
    }
}
