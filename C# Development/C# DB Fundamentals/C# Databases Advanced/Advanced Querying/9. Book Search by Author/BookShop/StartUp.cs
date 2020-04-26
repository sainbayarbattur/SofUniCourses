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

                Console.WriteLine(GetBooksByAuthor(db, input));
            }
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            var books = context.Books
                .Select(b => new { b.Title, b.Author, b.BookId })
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");
            }

            return result.ToString().TrimEnd();
        }
    }
}
