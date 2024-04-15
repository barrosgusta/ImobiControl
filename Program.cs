using ImobiControl.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ImobiControlContext>(options => options.UseNpgsql(connectionString));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "estado",
    pattern: "{controller=Estado}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "cidade",
    pattern: "{controller=Cidade}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "tipo",
    pattern: "{controller=Tipo}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "pessoa",
    pattern: "{controller=Pessoa}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "usuario",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "conta",
    pattern: "{controller=Conta}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "imovel",
    pattern: "{controller=Imovel}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "foto",
    pattern: "{controller=Foto}/{action=Index}/{id?}");

app.Run();
