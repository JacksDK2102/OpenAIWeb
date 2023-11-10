using Microsoft.EntityFrameworkCore;
using OpenAIWeb1.Areas.Identity.Data;
using OpenAIWeb1.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AISampleDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AISampleDbContextConnection' not found.");

builder.Services.AddDbContext<AISampleDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AISampleUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AISampleDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.MapRazorPages();
app.Run();
