using EquipmentService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EquipmentService.Infrastructure.Data;

public class EquipmentContext : DbContext
{
    private readonly IConfiguration _configuration;

    public EquipmentContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<EquipmentModel> EquipmentModels { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"),  
            b => b.MigrationsAssembly("EquipmentService.API"));
    }
}