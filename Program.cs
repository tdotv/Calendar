using Calendar.Interfaces;
using Calendar.Repositories;
using Calendar.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Dependency Injection + Repository Pattern
builder.Services.AddScoped<IEventRepository, EventRepository>();

// Data base connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseFirebird(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//  Globalization and Localization
// -----------------------------------------
// var supportedCultures = new[]
// {
//  new CultureInfo("en-US"),
//  new CultureInfo("fr"),
// };

// app.UseRequestLocalization(new RequestLocalizationOptions
// {
//     DefaultRequestCulture = new RequestCulture("en-US"),
//     // Formatting numbers, dates, etc.
//     SupportedCultures = supportedCultures,
//     // UI strings that we have localized.
//     SupportedUICultures = supportedCultures
// });
// -----------------------------------------

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
