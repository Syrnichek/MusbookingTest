using EquipmentService.Application.Commands;
using EquipmentService.Application.Handlers;
using EquipmentService.Application.Mappers;
using EquipmentService.Core.Repositories;
using EquipmentService.Infrastructure.Data;
using EquipmentService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("WebApiDatabase");

builder.Services.AddDbContext<EquipmentContext>(options => options.UseSqlite(connection));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(AddEquipmentCommand).Assembly,
    typeof(AddEquipmentCommandHandler).Assembly
));
builder.Services.AddGrpc();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddAutoMapper(typeof(EquipmentMapperProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGrpcService<EquipmentService.API.Services.EquipmentService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();