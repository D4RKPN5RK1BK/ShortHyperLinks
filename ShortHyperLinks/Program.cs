using Microsoft.EntityFrameworkCore;
using ShortHyperLinks.Data;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultMySQL");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SHLContext>(o => o.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(configure =>
{
    configure.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    configure.MapControllerRoute("links", "/link/{id?}", defaults: new {controller = "HyperLink", action = "Redirect"});
});

app.Run();
