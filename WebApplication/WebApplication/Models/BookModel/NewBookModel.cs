using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{

    public class NewBookModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public Genre Genre { get; set; }
        public int Id { get; set; }

    }
}
