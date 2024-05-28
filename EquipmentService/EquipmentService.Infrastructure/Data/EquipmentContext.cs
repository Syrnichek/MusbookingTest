using EquipmentService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EquipmentService.Infrastructure.Data;

public class EquipmentContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public EquipmentContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public DbSet<EquipmentModel> EquipmentModels { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"),  
            b => b.MigrationsAssembly("EquipmentService.API"));
    }
}