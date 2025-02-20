using System.ComponentModel.DataAnnotations;

namespace Cashier.Models;
public class Item 
{
    public int Id { get; set; }

    [Required (ErrorMessage = "Description is required")]
    public string? Description { get; set; }

    [Required (ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

     [Required (ErrorMessage = "Size is required")]
    public string? Size { get; set; }

     [Required (ErrorMessage = "Quantity is required")]
     [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 1")]
    public int Quantity { get; set; }

}