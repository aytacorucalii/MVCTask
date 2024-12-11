using GameStorePr.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorePr.MVC.DAL;

public class AppDbContext: DbContext 
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Game>Games { get; set; }

}
