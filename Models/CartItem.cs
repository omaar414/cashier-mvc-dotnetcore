using System.ComponentModel.DataAnnotations.Schema;

namespace Cashier.Models
{
    public class CartItem 
    {
        public List<Item> ItemsOnCart = new List<Item>();
    }
}