using DevSlkill.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevSlkill.Inventory.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
    }
}
