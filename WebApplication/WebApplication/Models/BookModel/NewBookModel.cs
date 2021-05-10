using Microsoft.AspNetCore.Http;

namespace WebApplication.Models
{

    public class NewBookModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile CoverImage { get; set; }
    }
}
