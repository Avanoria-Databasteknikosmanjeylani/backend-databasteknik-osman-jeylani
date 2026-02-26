using Domain.Instructors;
using Domain.Instructors.Repositories;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class InstructorRepository
	: IInstructorRepository
{
	private readonly CourseOnlineDbContext _context;

	public InstructorRepository(CourseOnlineDbContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Instructor instructor)
	{
		throw new NotImplementedException();
	}

	public async Task<Instructor?> AddAsync(Instructor instructor, CancellationToken ct)
	{
		var entity = new InstructorEntity
		{
			Id = instructor.Id,
			FirstName = instructor.FirstName,
			LastName = instructor.LastName,
			Email = instructor.Email,
			RoleId = instructor.Role.Id  
		};

		await _context.Instructors.AddAsync(entity, ct);
		await _context.SaveChangesAsync(ct);

		return instructor;
	}



	public async Task<IReadOnlyList<Instructor>> GetAllAsync(CancellationToken ct)
	{
		var entities = await _context.Instructors
			.Include(x => x.Role)
			.ToListAsync(ct);

		return entities.Select(entity =>
			new Instructor(
				entity.Id,
				entity.FirstName,
				entity.LastName,
				entity.Email,
				null,
				new InstructorRole(
					entity.Role.Id,
					entity.Role.Name
				)
			)
		).ToList();
	}


	public async Task<Instructor?> GetByEmailAsync(string email, CancellationToken ct)
	{
		var entity = await _context.Instructors
			.Include(x => x.Role)
			.FirstOrDefaultAsync(x => x.Email == email, ct);

		if (entity is null)
			return null;

		return new Instructor(
			entity.Id,
			entity.FirstName,
			entity.LastName,
			entity.Email,
			null,
			new InstructorRole(
				entity.Role.Id,
				entity.Role.Name
			)
		);
	}



	public async Task<Instructor?> GetByIdAsync(Guid id, CancellationToken ct)
	{
		var entity = await _context.Instructors
			.Include(x => x.Role)
			.FirstOrDefaultAsync(x => x.Id == id, ct);

		if (entity is null)
			return null;

		return new Instructor(
			entity.Id,
			entity.FirstName,
			entity.LastName,
			entity.Email,
			null,
			new InstructorRole(
				entity.Role.Id,
				entity.Role.Name
			)
		);
	}




	public async Task<bool> RemoveAsync(Guid id, CancellationToken ct)
	{
		var entity = await _context.Instructors
			.FirstOrDefaultAsync(x => x.Id == id, ct);

		if (entity is null)
			return false;

		_context.Instructors.Remove(entity);
		await _context.SaveChangesAsync(ct);

		return true;
	}




	public Task<Instructor?> UpdateAsync(Guid id, Instructor model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}

