namespace BookShop
{
    using BookShop.Initializer;
    using Data;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                int input = int.Parse(Console.ReadLine());

                Console.WriteLine(CountBooks(db, input));
            }
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var authors = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return authors.Count;
        }
    }
}
