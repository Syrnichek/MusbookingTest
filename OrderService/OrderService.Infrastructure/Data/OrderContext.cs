using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderService.Core.Entities;

namespace OrderService.Infrastructure.Data;

public class OrderContext : DbContext
{
    private readonly IConfiguration _configuration;

    public OrderContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<OrderModel> OrderModels { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"),  
            b => b.MigrationsAssembly("OrderService.API"));
        optionsBuilder.UseLazyLoadingProxies();
    }
}