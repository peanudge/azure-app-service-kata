using Microsoft.EntityFrameworkCore;

using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.  
builder.Services.AddControllersWithViews();

// Add DbContexts to the container.
builder.Services.AddDbContext<WeatherContext>(optionsBuilder =>
{
    string path = Path.Combine(
                Environment.CurrentDirectory, "Labware.db"
            );
    optionsBuilder
        .UseSqlite($"Filename={path}");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
