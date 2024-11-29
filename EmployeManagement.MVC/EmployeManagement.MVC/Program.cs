using EmployeManagement.MVC.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"))
);


var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
  );

  app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);

app.Run();
