using Microsoft.AspNetCore.Identity;
using ProyectoSistemaUsuarios.Models;
using ProyectoSistemaUsuarios.Servicios;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


////SERVICIO DE USUARIOS
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();

//SERVICIO USUARIOSTORE
builder.Services.AddTransient<IUserStore<Usuario>, UsuarioStore>();

//SERVICIO DE SIGNINMANAGER
builder.Services.AddTransient<SignInManager<Usuario>>();

//IDENTITY
builder.Services.AddIdentityCore<Usuario>(opciones =>
{
    opciones.Password.RequireDigit = false;
    opciones.Password.RequireLowercase = false;
    opciones.Password.RequireUppercase = false;
    opciones.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddHttpContextAccessor();

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

app.Run();
