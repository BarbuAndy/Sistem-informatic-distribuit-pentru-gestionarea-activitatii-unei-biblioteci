using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Branch
    {
        public int BranchId { get; set; }

        public int LibraryId { get; set; }
        public string Name { get; set; }
        public Library Library { get; set; }
        
    }
}
