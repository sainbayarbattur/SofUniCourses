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

                Console.WriteLine(GetBookTitlesContaining(db, input));
            }
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            var books = context.Books
                .Select(b => b.Title)
                .Where(b => b.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            //Console.WriteLine(result.Length);

            return result.ToString().TrimEnd();
        }
    }
}
