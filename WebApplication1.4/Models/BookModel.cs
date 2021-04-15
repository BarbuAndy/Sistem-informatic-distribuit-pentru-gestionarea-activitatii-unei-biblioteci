using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    [Microsoft.EntityFrameworkCore.Keyless]
    public class BookModel
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }

    }
}
