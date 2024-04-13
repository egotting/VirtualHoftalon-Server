using Microsoft.EntityFrameworkCore;
using VirtualHoftalon_Server.Models;
using VirtualHoftalon_Server.Repositories;
using VirtualHoftalon_Server.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ModelsContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();
