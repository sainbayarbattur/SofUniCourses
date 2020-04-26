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
                string command = Console.ReadLine();

                Console.WriteLine(GetBooksByAgeRestriction(db, command));
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = new StringBuilder();

            var bookTitles = context.Books
                .Select(b => new { b.AgeRestriction, b.Title })
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new { b.Title })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var bookTitle in bookTitles)
            {
                result.AppendLine(bookTitle.Title);
            }

            return result.ToString();
        }
    }
}
