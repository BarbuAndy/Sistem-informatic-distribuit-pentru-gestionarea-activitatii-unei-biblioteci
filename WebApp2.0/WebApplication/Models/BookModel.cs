using Microsoft.AspNetCore.Http;
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
        public string Genre { get; set; }

        public string ImageUrl { get; set; }
        public string NewTitle { get; set; }
        public IFormFile CoverImage { get; set; }

    }
}
