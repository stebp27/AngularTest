using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        //Is the Id enough?
        public Author Author { get; set; }

        public Book() { }

        public Book(string title, decimal price, int authorId, Author author)
        {
            Title = title;
            Price = price;
            AuthorId = authorId;
            Author = author;
        }


    }
}
