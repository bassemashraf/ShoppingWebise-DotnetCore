using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopingWebsite.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); 
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(Sp=> ShoppingCart.GetCart(Sp));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ShoppingDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.UseDeveloperExceptionPage();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
app.MapRazorPages();
DbInitializer.Seed(app);
app.Run();
