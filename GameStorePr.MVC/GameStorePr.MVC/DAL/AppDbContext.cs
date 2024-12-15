using GameStorePr.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStorePr.MVC.DAL;

public class AppDbContext: IdentityDbContext<AppUser> 
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Game>Games { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Review>()
            .HasOne(g=>g.Game)
            .WithMany(r=>r.Reviews)
            .HasForeignKey(g=>g.GameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
