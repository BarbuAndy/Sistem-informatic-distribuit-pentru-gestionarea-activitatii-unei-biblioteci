namespace WebApplication.context
{
    public class Stock
    {
        public string StockId { get; set; }
        public string BranchId { get; set; }
        public Branch Branch { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }

    }
}