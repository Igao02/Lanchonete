using LanchoneteMVC.Domain.Models;
using LanchoneteMVC.Domain.Repositories;
using LanchoneteMVC.Persistence.Context;
using LanchoneteMVC.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'LanchoneteMVC' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILancheRepository, LancheRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();



//builder.Services.AddDbContext<AppDbContext>(options =>
//{
  //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //builder.Services.AddTransient<ILancheRepository, LancheRepository>();
    //builder.Services.AddTransient<ICatgoriaRepository, ICatgoriaRepository>();
    
//});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
         name: "categoriaFiltro",
         pattern: "Lanche/{action}/{categoria?}",
         defaults: new { Controller = "Lanche", Action = "List" }
        );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


/* //Aqui define qual tela será aberta primeiro na aplicação
   app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
*/

app.Run();
