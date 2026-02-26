using Application.Common.Results;
using Application.Extensions.Caching;
using Application.Instructors.Contracts;
using Application.Instructors.Inputs;
using Domain.Modules.Courses.Models;
using Domain.Modules.Courses.Repositories;
using Infrastructure;
using Infrastructure.Persistence.EFC.Contexts;
using Microsoft.EntityFrameworkCore;
using Presentation.API.Contracts.Courses;





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

app.MapPost("/api/instructors", async (
	CreateInstructorInput input,
	IInstructorService service,
	CancellationToken ct) =>
{
	var result = await service.CreateInstructorAsync(input, ct);

	if (result.Success)
		return Results.Ok(result.Value);

	return result.ErrorType switch
	{
		ErrorTypes.BadRequest => Results.BadRequest(result.ErrorMessage),
		ErrorTypes.NotFound => Results.NotFound(result.ErrorMessage),
		ErrorTypes.Conflict => Results.Conflict(result.ErrorMessage),
		ErrorTypes.Unexpected => Results.Problem(result.ErrorMessage),
		_ => Results.Problem("Unknown error")
	};
});

app.MapGet("/api/instructors/{id:guid}", async (
	Guid id,
	IInstructorService service,
	CancellationToken ct) =>
{
	var result = await service.GetInstructorByIdAsync(id, ct);

	if (result.Success)
		return Results.Ok(result.Value);

	return result.ErrorType switch
	{
		ErrorTypes.NotFound => Results.NotFound(result.ErrorMessage),
		ErrorTypes.Unexpected => Results.Problem(result.ErrorMessage),
		_ => Results.Problem("Unknown error")
	};
});

app.MapDelete("/api/instructors/{id:guid}", async (
	Guid id,
	IInstructorService service,
	CancellationToken ct) =>
{
	var result = await service.DeleteInstructorAsync(id, ct);

	if (result.Success)
		return Results.NoContent();

	return result.ErrorType switch
	{
		ErrorTypes.NotFound => Results.NotFound(result.ErrorMessage),
		ErrorTypes.BadRequest => Results.BadRequest(result.ErrorMessage),
		_ => Results.Problem(result.ErrorMessage)
	};
});
app.MapGet("/api/instructors", async (
	IInstructorService service,
	CancellationToken ct) =>
{
	var instructors = await service.GetInstructorsAsync(ct);
	return Results.Ok(instructors);
});

app.MapPost("/api/courses", async (
	CourseCreateInput input,
	ICourseRepository repo,
	CancellationToken ct) =>
{
	var course = new Course(
		Guid.NewGuid(),
		input.Title,
		input.Description,
		input.Length
	);

	await repo.AddAsync(course, ct);

	return Results.Created($"/api/courses/{course.Id}", course);
});

app.MapGet("/api/courses", async (
	ICourseRepository repo,
	CancellationToken ct) =>
{
	var courses = await repo.GetAllAsync(ct);
	return Results.Ok(courses);
});

app.MapGet("/api/courses/{id:guid}", async (
	Guid id,
	ICourseRepository repo,
	CancellationToken ct) =>
{
	var course = await repo.GetByIdAsync(id, ct);

	return course is null
		? Results.NotFound()
		: Results.Ok(course);
});

app.MapPut("/api/courses/{id:guid}", async (
	Guid id,
	CourseUpdateInput input,
	ICourseRepository repo,
	CancellationToken ct) =>
{
	var updatedCourse = new Course(
		id,
		input.Title,
		input.Description,
		input.Length
	);

	var success = await repo.UpdateAsync(updatedCourse, ct);

	return success
		? Results.NoContent()
		: Results.NotFound();
});

app.MapDelete("/api/courses/{id:guid}", async (
	Guid id,
	ICourseRepository repo,
	CancellationToken ct) =>
{
	var success = await repo.DeleteAsync(id, ct);

	return success
		? Results.NoContent()
		: Results.NotFound();
});


app.Run();

public partial class Program { }

