namespace WebApplication.context
{
    public class Stock
    {
        public int StockId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}