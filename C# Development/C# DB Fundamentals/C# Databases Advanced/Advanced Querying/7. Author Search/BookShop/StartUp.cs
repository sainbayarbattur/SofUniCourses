namespace BookShop
{
    using Data;
    using System.Text;
    using System.Linq;
    using System;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                var date = Console.ReadLine();

                Console.Write(GetAuthorNamesEndingIn(db, date));
            }
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = new StringBuilder();

            var authors = context.Authors
                .Select(a => new { a.FirstName, a.LastName })
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                .OrderBy(b => b.FullName)
                .ToList();

            foreach (var author in authors)
            {
                result.AppendLine(author.FullName);
            }

            return result.ToString();
        }
    }
}
