using Microsoft.EntityFrameworkCore;
using Uniqlo.MVC.Models;

namespace Uniqlo.MVC.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<SliderItem> SliderItems { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
