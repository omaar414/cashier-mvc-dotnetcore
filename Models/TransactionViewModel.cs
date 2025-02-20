namespace Cashier.Models
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}