using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.context
{
    public class Branch
    {
        public string BranchId { get; set; }

        public string LibraryId { get; set; }
        public Library Library { get; set; }
        
    }
}
