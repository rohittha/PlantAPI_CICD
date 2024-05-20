using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlantWateringAPI.Models;
using System;

//var builder = WebApplication.CreateBuilder(args);


//var MyOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyOrigins, builder =>
//    {
//        builder
//           .WithOrigins("http://localhost:3000", "http://localhost:3000/") // Specify the allowed origin(s)
//            .AllowAnyMethod()
//            .AllowAnyHeader();
//    });
//});

//// Add services to the container.
//var PlantsconnectionString = builder.Configuration.GetConnectionString("PlantsConnection");
//builder.Services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(PlantsconnectionString));


var MyOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var PlantsconnectionString = builder.Configuration.GetConnectionString("PlantsConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(PlantsconnectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyOrigins, builder =>
    {
        builder
           .WithOrigins("http://localhost:3000", "http://localhost:3000/") // Specify the allowed origin(s)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

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
app.UseCors(MyOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
