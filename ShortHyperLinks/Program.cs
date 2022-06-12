using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ShortHyperLinks.Data;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultMySQL");
ServerVersion dbVersion = new MySqlServerVersion(new Version(10, 6, 8));
Action<MySqlDbContextOptionsBuilder> action;

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SHLContext>(o => o.UseMySql(connection, dbVersion));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(configure =>
{
    configure.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    configure.MapControllerRoute("links", "/link/{id?}", defaults: new {controller = "HyperLink", action = "RedirectToURL" });
});

app.Run();
