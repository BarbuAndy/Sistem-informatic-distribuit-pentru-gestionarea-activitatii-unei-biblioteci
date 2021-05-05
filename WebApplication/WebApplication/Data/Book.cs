using Olympia_Library.Data;

namespace Olympia_Library.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
