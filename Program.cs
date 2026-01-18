using HealthTrack.Data;
using HealthTrack.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllersWithViews();

// Configurar o DbContext
builder.Services.AddDbContext<HealthTrackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();


// Configurar autenticação com cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Account/Login"; // Página de login
        options.LogoutPath = "/Account/Logout"; // Página de logout
        options.AccessDeniedPath = "/Account/AccessDenied"; // Página de acesso negado
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Duração do cookie
        options.SlidingExpiration = true; // Renovação automática do cookie
    });

var app = builder.Build();

// Configurar o pipeline de solicitações HTTP
if (app.Environment.IsDevelopment())
{
    // Permitir erros detalhados no ambiente de desenvolvimento
    app.UseDeveloperExceptionPage();
}
else
{
    // Configurar exceções e HTTPS no ambiente de produção
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseRouting();

// Ativar autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Configurar rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();