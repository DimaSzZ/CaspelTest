using System.Reflection;
using CaspelTest.Parsistence.Models;
using Microsoft.EntityFrameworkCore;

namespace CaspelTest.Parsistence.MSSQLDbContext;

public class SqlDbContext : DbContext
{
    //dotnet ef migrations add InitialCreate --project 'C:\Users\komuk\RiderProjects\CaspelTest\CaspelTest\'
    //--output-dir 'C:\Users\komuk\RiderProjects\CaspelTest\CaspelTest\Parsistence\Migrations'
    //and
    // dotnet ef database update --project 'C:\Users\komuk\RiderProjects\CaspelTest\CaspelTest\'
    // --startup-project 'C:\Users\komuk\RiderProjects\CaspelTest\CaspelTest\'
    
    private readonly IConfiguration _configuration;
    public SqlDbContext(DbContextOptions<SqlDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<BookModel> BookModels { get; set; } = null!;
    public DbSet<OrderModel> OrderModels { get; set; } = null!;

    ///<summary>
    /// Путь к строке подключения, в appsettings.json
    ///</summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
    ///<summary>
    /// Путь к строке подключения, в appsettings.json
    ///</summary>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        builder.Entity<OrderModel>(om =>
        {
            om.Navigation(om => om.OrderBooks).AutoInclude();
        });
        //Последний билдер нужен для предсавления связи между OrderModel и OrderBooks, а еще AutoInclude в теории повышал бы производительность
        //из за уменьшения частоты обращений в бд
    }
}