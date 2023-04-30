using Microsoft.EntityFrameworkCore;

using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllersWithViews();

// Add DbContexts to the container.
var connectionString = builder.Configuration.GetConnectionString("MSSQL");

builder.Services.AddDbContext<LabwareContext>(
    options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseDefaultFiles();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

if (app.Environment.IsDevelopment())
{
    using var serviceScope = app.Services.CreateScope();
    var isExistLabwareDatabase = serviceScope.ServiceProvider
        .GetRequiredService<LabwareContext>()
        .Database.EnsureCreated();

    if (!isExistLabwareDatabase)
    {
        Console.WriteLine($"Already existed Labware Database.");
    }
}


app.Run();
