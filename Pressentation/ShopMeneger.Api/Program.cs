using ShopMeneger.Data;
using ShopMeneger.Application;
using ShopMeneger.DataAccess;
using ShopMeneger.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddUserSecrets<ShopMenegerContext>().Build();

builder.Services.AddDbContext<ShopMenegerContext>(options =>
{
    var conectionString = builder.Configuration
    .GetConnectionString("EfCoreShopMenegerDataBase");

    options.UseSqlServer(conectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddShopMenegerDataAccess();
builder.Services.AddShopMenegerData(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
