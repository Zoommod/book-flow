using BookFlow.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookFlow.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura o DbContext para o Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configura o Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Não é necessário confirmar a conta para login
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();  // Adiciona o provedor de tokens para redefinição de senha, etc.

// Add session and cookie configuration if needed for user authentication (optional)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;  // Protege o cookie contra XSS
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Tempo de expiração do cookie
    options.SlidingExpiration = true;  // Expiração deslizante
    options.LoginPath = "/Account/Login";  // Caminho para login caso não autenticado
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilita a autenticação e autorização
app.UseAuthentication();  // Necessário para permitir a autenticação de usuários
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
