using System.Text.Json.Serialization;
using MedievalMMO.BL;
using MedievalMMO.DAL;
using MedievalMMO.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MedievalDbContext>(options =>
    options.UseSqlite("Data Source=../MedievalDb.db"));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IManager, Manager>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

InitializeDatabase(dropDatabase: false);

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

void InitializeDatabase(bool dropDatabase)
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        MedievalDbContext dbCtx = scope.ServiceProvider.GetRequiredService<MedievalDbContext>();
        if (dbCtx.CreateDatabase(dropDatabase))
        {
            DataSeeder.Seed(dbCtx);
        }
    }
}