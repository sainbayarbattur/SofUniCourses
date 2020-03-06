namespace Articles_2._0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public Book(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public void SortByTitle(List<Book> title)
            {
                foreach (var item in title.OrderBy(x => x.Title))
                {
                    item.OverrideToString();
                }
            }
            public void SortByContent(List<Book> content)
            {
                foreach (var item in content.OrderBy(x => x.Content))
                {
                    item.OverrideToString();
                }
            }
            public void SortByAuthor(List<Book> author)
            {
                foreach (var item in author.OrderBy(x => x.Author))
                {
                    item.OverrideToString();
                }
            }
            public void OverrideToString()
            {
                Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var result = new List<Book>();
            Book Outbook = new Book("1","2","3");
            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                Book book = new Book(input[0], input[1], input[2]);
                result.Add(book);
            }
            string method = Console.ReadLine();

            PrintResult(Outbook,result, method);
        }

        public static void PrintResult(Book result ,List<Book>result1, string comm)
        {
            switch (comm)
            {
                case "title":
                    result.SortByTitle(result1);
                    break;
                case "content":
                    result.SortByContent(result1);
                    break;
                case "author":
                    result.SortByAuthor(result1);
                    break;
            }

        }
    }
}
