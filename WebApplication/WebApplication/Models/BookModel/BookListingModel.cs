using Olympia_Library.Data;


namespace Olympia_Library.Models.BookModel
{
    public class BookListingModel
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
