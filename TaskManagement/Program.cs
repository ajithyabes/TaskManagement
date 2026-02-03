using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Entities.DBContext;
using TaskManagement.Data.Implementation;
using TaskManagement.Data.Interface;
using TaskManagement.Service.Implementation;
using TaskManagement.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB Connection
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

//Dependency Injection
builder.Services.AddScoped<ITaskManagementService, TaskManagementService>();
builder.Services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();

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
