using Microsoft.EntityFrameworkCore;
using OrderService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("WebApiDatabase");

builder.Services.AddDbContext<OrderContext>(options => options.UseSqlite(connection));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();