using Domain.Instructors;
using Domain.Instructors.Repositories;
using Infrastructure.Persistence.EFC.Contexts;
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

    public Task<Instructor> AddAsync(Instructor model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Instructor>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Instructor?> GetByEmailAsync(string email, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Instructor?> GetByIdAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Instructor?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Instructor?> UpdateAsync(string id, Instructor model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Instructor?> UpdateAsync(Guid id, Instructor model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}

