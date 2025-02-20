namespace Cashier.Models
{
    public class Purchase 
    {
        public int Id { get; set;}
        public DateTime Date { get; set;}

        public int TotalItems { get; set;}
        public decimal TotalAmount { get; set;}
        public List<Item> PurchasedItems { get; set;} = new List<Item>();

    }
}