using casecalismam2.Models;
using Microsoft.EntityFrameworkCore;

namespace casecalismam2.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }

        public DbSet<Product> Products { get; set; }
    }
}
