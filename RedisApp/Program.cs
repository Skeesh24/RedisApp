using Microsoft.EntityFrameworkCore;
using RedisApp.Services;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

// коннектим джейсн конфиг 
var settings = new ConfigurationManager().AddJsonFile("appsettings.json").Build();

// дефолтно коннектим постгрес
builder.Services.AddDbContext<RedisApp.Domain.AppContext>(options =>
{
    options.UseNpgsql(settings.GetConnectionString("DefaultConnection"));
});

// коннектим кэширователь
builder.Services.AddTransient<RedisService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// привязываем джейсн конфиг к классу конфига 
app.Configuration.Bind("Project", new Config());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
