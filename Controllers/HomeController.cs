using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cashier.Models;
using Cashier.Data;

namespace Cashier.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CashierDbContext _context;

    private static CartItem Cart = new CartItem();

    public HomeController(ILogger<HomeController> logger, CashierDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var allPurchases = _context.purchases.OrderBy( item => item.Id).ToList();
        return View(allPurchases);
    }
    public IActionResult Transaction()
    {
        var allTransactionCartItems = Cart.ItemsOnCart.ToList();
        var totalAmount = Cart.ItemsOnCart.Sum(item => item.Price);
        var totalQuantity = Cart.ItemsOnCart.Count();

        ViewBag.TotalAmount = totalAmount;
        ViewBag.TotalQuantity = totalQuantity;

        var transactioViewModel = new TransactionViewModel {
            Id = 0,
            Items = allTransactionCartItems.ToList()
        };


        return View(transactioViewModel);
    }
    public IActionResult AddItemToCart(int? id)
    {
        if(id == null)
        {
            return View("Transaction");
        }
        var newItem = _context.Items.SingleOrDefault(item => item.Id == id);
        if (newItem != null)
        {
            Cart.ItemsOnCart.Add(newItem);
        }

        return RedirectToAction("Transaction");
    }
    public  IActionResult DeleteCartItem(int id)
    {
        var itemToRemove = Cart.ItemsOnCart.FirstOrDefault(item => item.Id == id);
        if (itemToRemove != null)
        {
            Cart.ItemsOnCart.Remove(itemToRemove);
        }
        
        return RedirectToAction("Transaction");
    }

     public IActionResult AddPurchase()
     {
        if(!Cart.ItemsOnCart.Any())
        {
            TempData["Error"] = "No items in cart";
            return View("Transaction");
        }
        //Manage the quantity of each Item on storage
        foreach (var cartItem in Cart.ItemsOnCart)
        {
            var storageItem = _context.Items.FirstOrDefault(item => item.Id == cartItem.Id);
            if (storageItem != null && storageItem.Quantity > 0)
            {
                storageItem.Quantity -= 1; // Restamos 1 por cada aparición en el carrito
            }
        }
       
        _context.SaveChanges();  //Save the changes

        
        var existingItems = Cart.ItemsOnCart.Select( cartItem => _context.Items.FirstOrDefault(item => item.Id == cartItem.Id)).Where(item => item != null).ToList();

        if(existingItems.Any())
        {
            var newPurchase = new Purchase {
            Date = DateTime.UtcNow,
            TotalItems = Cart.ItemsOnCart.Count(),
            TotalAmount = Cart.ItemsOnCart.Sum(item => item.Price),
            PurchasedItems = existingItems
        };

        _context.purchases.Add(newPurchase);
        _context.SaveChanges();

        Cart.ItemsOnCart.Clear();
        }
        
        return RedirectToAction("Index");
     }

    public IActionResult Storage()
    {
        var storageViewModel = new StorageViewModel
        {
            Items = _context.Items.OrderBy( item => item.Id).ToList(),
            NewItem = new Item()
        };
        return View(storageViewModel);
    }

    public IActionResult AddItemToStorage(StorageViewModel model)
    {
        //If there is any error or problem with the model, it will be handled here
        if(!ModelState.IsValid)
        {
            model.Items =_context.Items.OrderBy( item => item.Id).ToList();
            return View("Storage", model);
        }

        _context.Items.Add(model.NewItem);
        _context.SaveChanges();
        return RedirectToAction("Storage");
    }

    public ActionResult DeleteStorageItem(int id)
    {
        var itemToDelete = _context.Items.SingleOrDefault(item => item.Id == id);

        if (itemToDelete != null)
        {
            _context.Remove(itemToDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Storage");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
