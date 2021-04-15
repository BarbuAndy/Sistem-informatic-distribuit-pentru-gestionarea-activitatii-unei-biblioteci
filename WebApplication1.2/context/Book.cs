using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.context
{
    public class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
