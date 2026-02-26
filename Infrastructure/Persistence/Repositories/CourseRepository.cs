using Domain.Modules.Courses.Models;
using Domain.Modules.Courses.Repositories;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

public class CourseRepository : ICourseRepository
{
	private readonly CourseOnlineDbContext _context;

	public CourseRepository(CourseOnlineDbContext context)
	{
		_context = context;
	}

	public async Task<Course?> GetByIdAsync(Guid id, CancellationToken ct)
	{
		var entity = await _context.Courses
			.FirstOrDefaultAsync(x => x.Id == id, ct);

		if (entity is null)
			return null;

		return new Course(entity.Id, entity.Title, entity.Description, entity.Length);
	}

	public async Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken ct)
	{
		var entities = await _context.Courses.ToListAsync(ct);

		return entities
			.Select(e => new Course(e.Id, e.Title, e.Description, e.Length))
			.ToList();
	}

	public async Task<Course> AddAsync(Course course, CancellationToken ct)
	{
		var entity = new CourseEntity
		{
			Id = course.Id,
			Title = course.Title,
			Description = course.Description,
			Length = course.Length
		};

		await _context.Courses.AddAsync(entity, ct);
		await _context.SaveChangesAsync(ct);

		return course;
	}

    Task ICourseRepository.AddAsync(Course course, CancellationToken ct)
    {
        return AddAsync(course, ct);
    }

	public async Task<bool> UpdateAsync(Course course, CancellationToken ct)
	{
		var entity = await _context.Courses
			.FirstOrDefaultAsync(x => x.Id == course.Id, ct);

		if (entity is null)
			return false;

		entity.Title = course.Title;
		entity.Description = course.Description;
		entity.Length = course.Length;

		await _context.SaveChangesAsync(ct);

		return true;
	}

	public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
	{
		var entity = await _context.Courses
			.FirstOrDefaultAsync(x => x.Id == id, ct);

		if (entity is null)
			return false;

		_context.Courses.Remove(entity);
		await _context.SaveChangesAsync(ct);

		return true;
	}

}
