using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{

    public class BookModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public Genre Genre { get; set; }

    }
}
