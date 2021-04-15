using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.context
{
    public class Borrow
    {
        public int BorrowId { get;set; }
        public int ReaderId { get; set; }
        public int BranchId { get; set; }
        public int BookId { get; set; }

        public Reader Reader { get; set; }
        public Branch Branch { get; set; }
        public Book Book { get; set; }
    }
}
