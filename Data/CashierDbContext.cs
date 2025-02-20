
using Cashier.Models;
using Microsoft.EntityFrameworkCore;

namespace Cashier.Data
{
    public class CashierDbContext : DbContext
    {
        public CashierDbContext(DbContextOptions<CashierDbContext> options) : base(options) {}

        public DbSet<Item> Items { get; set; }
        public DbSet<Purchase> purchases{ get; set; }
    }
}

