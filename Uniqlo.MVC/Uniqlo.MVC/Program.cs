using Microsoft.EntityFrameworkCore;
using Uniqlo.MVC.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);
{
    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


    var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}"
);

app.Run();
