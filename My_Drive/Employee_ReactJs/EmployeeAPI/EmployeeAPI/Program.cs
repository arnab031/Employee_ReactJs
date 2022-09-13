using EmployeeAPI;
using EmployeeAPI.Mapper;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors((options) =>
//{
//    options.AddPolicy("reactApplication", (builder) =>
//    {
//        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().WithMethods("GET", "POST", "PUT", "DELETE").WithExposedHeaders("*");
//    });
//});
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mappings));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("reactApplication");
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

