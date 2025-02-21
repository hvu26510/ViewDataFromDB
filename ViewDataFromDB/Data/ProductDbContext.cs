using Microsoft.EntityFrameworkCore;
using ViewDataFromDB.Models;

namespace ViewDataFromDB.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        { }
        public DbSet<Product> products { get; set; }
        public DbSet<SuKien> suKiens { get; set; }
        public DbSet<Ve>    ves { get; set; }   
    }
}
