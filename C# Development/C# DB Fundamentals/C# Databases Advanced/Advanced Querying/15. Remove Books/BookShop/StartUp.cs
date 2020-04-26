namespace BookShop
{
    using BookShop.Models;
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
                var input = Console.ReadLine();

                Console.WriteLine(RemoveBooks(db));
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToRemove);

            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}
