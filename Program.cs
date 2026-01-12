using Microsoft.EntityFrameworkCore;
using Auth.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));


builder.Services.AddMvc();
//builder.Services.AddSession();
builder.Services.AddSession( options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Register}");



app.UseStaticFiles();
app.UseSession();


app.Run();
