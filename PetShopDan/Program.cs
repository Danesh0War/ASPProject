using Microsoft.EntityFrameworkCore;
using PetShopDan.Data;
using PetShopDan.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();
builder.Services.AddControllersWithViews();
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<DataContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute("Default", "{controller=home}/{action=Index}/{id?}");
app.Run();