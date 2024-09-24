using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using ProyectoSistemaUsuarios.Models;
using ProyectoSistemaUsuarios.Servicios;

var builder = WebApplication.CreateBuilder(args);

//POLITICA DE USUARIOS AUTENTICADOS
var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();


//POLITICA DE USUARIOS AUTENTICADOS A NIVEL GLOBAL
builder.Services.AddControllersWithViews(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
});


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


//CONFIGURAR EL USO DE COOKIES PARA AUTENTICACIÓN
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
}).AddCookie(IdentityConstants.ApplicationScheme, opciones =>
{
    opciones.LoginPath = "/Usuario/Login";
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
