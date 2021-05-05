using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olympia_Library.Data
{
    public class Borrow
    {
        public int BorrowId { get;set; }

        public ApplicationUser User { get; set; }
        public Branch Branch { get; set; }
        public Book Book { get; set; }
        public int Amount { get; set; }
    }
}
