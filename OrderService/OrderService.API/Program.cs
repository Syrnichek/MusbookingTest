using EquipmentService.Application;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Commands;
using OrderService.Application.Handlers;
using OrderService.Application.Mappers;
using OrderService.Core.Repositories;
using OrderService.Infrastructure.Data;
using OrderService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("WebApiDatabase");
var grpcConnection = builder.Configuration.GetConnectionString("GrpcConnection");

builder.Services.AddDbContext<OrderContext>(options => options.UseSqlite(connection));
builder.Services.AddGrpc();
builder.Services.AddGrpcClient<equipmentService.equipmentServiceClient>(o =>
{
    o.Address = new Uri(grpcConnection);
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(AddEquipmentCommand).Assembly,
    typeof(AddEquipmentCommandHandler).Assembly
));
builder.Services.AddAutoMapper(typeof(OrderMapperProfile));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();