using EmployeManagement.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagement.MVC.DAL;

public class AppDBContext: DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<Service> Services { get; set; }
    public AppDBContext(DbContextOptions options) : base(options) 
    { 

    }
}
