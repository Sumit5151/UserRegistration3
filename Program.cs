using Microsoft.EntityFrameworkCore;
using UserRegistration3.BusinessAccessLayer.UserRepository;
using UserRegistration3.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BrightDb2Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("BrightDBConnectionString")
    )) ;

builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
