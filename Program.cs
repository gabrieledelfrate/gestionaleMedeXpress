using gestionaleMedeXpress.Models;
using gestionaleMedeXpress.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi le impostazioni del database al servizio di configurazione
builder.Services.Configure<MedeXpressDatabaseSettings>(
    builder.Configuration.GetSection("MedeXpressDatabaseSettings"));

// Aggiungi OrderService come servizio
builder.Services.AddSingleton<OrderService>();

// Aggiungi supporto per i controller con le viste
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura la pipeline di richiesta HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
