namespace WebApplication.Data
{
    public class Stock
    {
        public int StockId { get; set; }
        public Branch Branch { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}