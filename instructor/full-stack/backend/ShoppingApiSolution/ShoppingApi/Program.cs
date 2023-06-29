using Microsoft.EntityFrameworkCore;
using ShoppingApi.Controllers;
using ShoppingApi.Controllers.ShoppingList;
using ShoppingApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var shoppingConnectionString = builder.Configuration.GetConnectionString("shopping") ?? throw new Exception("No Connection String for Shopping");

builder.Services.AddDbContext<ShoppingDataContext>(options =>
{
    options.UseNpgsql(shoppingConnectionString);
});

builder.Services.AddScoped<ILookupTheStatus, StatusLookup>();
builder.Services.AddScoped<IManageTheShoppingList, PostgresShoppingManager>();

builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(); // Handle the whole cors thing while it is running.
app.UseAuthorization();

app.MapControllers();

app.Run();
