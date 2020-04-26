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
                System.Console.Write(CountCopiesByAuthor(db));
            }
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = new StringBuilder();

            var authors = context.Authors
                .Select(a => new { a.FirstName, a.LastName, BookCopies = a.Books.Sum(b => b.Copies) })
                .OrderByDescending(a => a.BookCopies)
                .Select(a => new { Format = a.FirstName + " " + a.LastName + " - " + a.BookCopies })
                .ToList();

            foreach (var author in authors)
            {
                result.AppendLine(author.Format);
            }

            return result.ToString();
        }
    }
}
