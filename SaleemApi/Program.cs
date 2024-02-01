using Microsoft.EntityFrameworkCore;
using SaleemApi.Context;
using SaleemApi.Interface;
using SaleemApi.Service;
using SaleemApi.Unit_Of_Work;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("Database"));
});
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
// Unit of work Regestrations
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
