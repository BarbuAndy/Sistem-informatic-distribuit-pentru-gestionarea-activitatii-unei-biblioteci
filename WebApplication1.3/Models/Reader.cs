using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.context
{
    public class Reader
    {
        public string ReaderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LibraryId { get; set; }

        public Library Library { get; set; }

        public bool Welcome { get; set; }
    }
}
