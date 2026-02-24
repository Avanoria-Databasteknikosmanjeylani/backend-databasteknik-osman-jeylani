using Infrastructure;
using Application.Extensions.Caching;
using Infrastructure.Persistence.EFC.Contexts;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddApplication(builder.Configuration, builder.Environment);

builder.Services.AddDbContext<CourseOnlineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CourseOnlineDB")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x  => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());



app.Run();

