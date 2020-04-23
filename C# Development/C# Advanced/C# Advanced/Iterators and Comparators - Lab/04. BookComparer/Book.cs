using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if (this.Year == other.Year)
            {
                return this.Title.CompareTo(other.Title);
            }

            return this.Year.CompareTo(other.Year);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}