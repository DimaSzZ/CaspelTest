using CaspelTest.AutoMapper.Mapper;
using CaspelTest.Middleware;
using CaspelTest.Parsistence.MSSQLDbContext;
using CaspelTest.Repositories;
using CaspelTest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBookRepository,BookService>();
builder.Services.AddScoped<IOrderRepository,OrderService>();
builder.Services.AddAutoMapper(typeof(MapBook),typeof(MapOrder));

// Add controllers
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
