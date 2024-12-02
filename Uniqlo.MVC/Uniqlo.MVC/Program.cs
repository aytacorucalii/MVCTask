using Microsoft.EntityFrameworkCore;
using Uniqlo.MVC.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);
<<<<<<< HEAD
=======
{
    app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


>>>>>>> 392bd9629de96522a722696e92c9783be6fb895c
    var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
 );
 app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}"
);

app.Run();
