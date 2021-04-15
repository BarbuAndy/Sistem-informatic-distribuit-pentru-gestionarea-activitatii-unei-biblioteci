using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.context
{
    public class Borrow
    {
        public string BorrowId { get;set; }
        public string ReaderId { get; set; }
        public string BranchId { get; set; }
        public string BookId { get; set; }

        public Reader Reader { get; set; }
        public Branch Branch { get; set; }
        public Book Book { get; set; }
    }
}
