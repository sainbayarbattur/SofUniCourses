using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{

    class Article
    {
        public string  Title { get; set; }
        public string  Content { get; set; }
        public string  Author { get; set; }

        public Article (string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public void Edit(string newEdit)
        {
            Content = newEdit;
        }
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;

        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public  void OverrideToString ()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string title = input[0];
            string content = input[1];
            string author = input[2];

            var article = new Article(title, content, author);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string [] currentInput = Console.ReadLine()
                    .Split(new char[] {':'},StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = currentInput[0];

                switch (command)
                {
                    case "Edit":
                        string newContent = currentInput[1].Trim();

                        article.Edit(newContent);

                        break;

                    case "ChangeAuthor":
                        string newAuthor = currentInput[1].Trim();

                        article.ChangeAuthor(newAuthor);

                        break;

                    case "Rename":

                        string newTitle = currentInput[1].Trim();

                        article.Rename(newTitle);
                        break;
                }

            }
            article.OverrideToString();
        }
    }
}