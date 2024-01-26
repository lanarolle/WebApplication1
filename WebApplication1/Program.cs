using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using WebApplication1.BusinessLogic.Services;
using WebApplication1.DataAccess;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});*/

builder.Services.AddDbContext<ApplicationDBContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 


builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IcoursesRepository, coursesRepository>();
builder.Services.AddScoped<IStudentCoursesRepository, StudentCoursesRepository>();
builder.Services.AddScoped<ISheduledRepository, SheduledRepository>();

builder.Services.AddScoped<coursesService, coursesService>();
builder.Services.AddScoped<PeopleService, PeopleService>();
builder.Services.AddScoped<StudentCoursesService, StudentCoursesService>();
builder.Services.AddScoped<StudentService, StudentService>();
builder.Services.AddScoped<SheduledService, SheduledService>();


builder.Services.AddCors(options => {
    options.AddPolicy(name: "AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:60818/").AllowAnyHeader().AllowAnyHeader();
    });
});


var app = builder.Build();

//DB Context for reguster


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//To connect with a front end client
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
