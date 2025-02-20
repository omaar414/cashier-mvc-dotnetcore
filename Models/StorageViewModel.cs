namespace Cashier.Models
{
    public class StorageViewModel
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public Item NewItem { get; set; } = new Item();
    }
}