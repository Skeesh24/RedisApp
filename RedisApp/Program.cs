using Microsoft.EntityFrameworkCore;
using RedisApp.Services;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ ������ 
var settings = new ConfigurationManager().AddJsonFile("appsettings.json").Build();

// �������� ��������� ��������
builder.Services.AddDbContext<RedisApp.Domain.AppContext>(options =>
{
    options.UseNpgsql(settings.GetConnectionString("DefaultConnection"));
});

// ��������� ������������
builder.Services.AddTransient<RedisService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ����������� ������ ������ � ������ ������� 
app.Configuration.Bind("Project", new Config());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
