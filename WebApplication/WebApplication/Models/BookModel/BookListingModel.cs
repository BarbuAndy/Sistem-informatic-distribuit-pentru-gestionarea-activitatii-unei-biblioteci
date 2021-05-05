﻿using Olympia_Library.Data;


namespace Olympia_Library.Models.BookModel
{
    public class BookListingModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public string ImageUrl { get; set; }
    }
}
