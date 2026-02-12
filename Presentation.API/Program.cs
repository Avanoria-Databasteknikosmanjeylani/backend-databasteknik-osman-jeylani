using Infrastructure.Persistence.EFC.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();

builder.Services.AddDbContext<CourseOnlineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CourseOnlineDB")));

var app = builder.Build();



app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x  => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



app.Run();

