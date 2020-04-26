namespace BookShop
{
    using BookShop.Initializer;
    using Data;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                IncreasePrices(db);
            }
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncreasePriceOn = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in context.Books)
            {
                //System.Console.Write(book.Price);

                book.Price += 5;

                //System.Console.WriteLine(book.Price);
            }

            context.SaveChanges();
        }
    }
}
