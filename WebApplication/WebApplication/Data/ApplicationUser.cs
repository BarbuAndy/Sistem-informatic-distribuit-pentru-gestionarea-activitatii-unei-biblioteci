using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia_Library.Data
{
    
    public class ApplicationUser : IdentityUser
    {
        public int ReaderId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Created { get; set; }
    }
}
