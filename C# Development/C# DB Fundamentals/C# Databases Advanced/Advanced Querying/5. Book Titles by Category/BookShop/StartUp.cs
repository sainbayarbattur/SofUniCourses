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
                var input = Console.ReadLine();

                Console.Write(GetBooksByCategory(db, input));
            }
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var listInput = input.Split().ToList();

            var result = new StringBuilder();

            var bookTitles = context.Books
                .Select(b => new { b.Title, b.BookCategories})
                .Where(b => b.BookCategories.Any(bc => listInput.Any(c => c.ToLower() == bc.Category.Name.ToLower())))
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
