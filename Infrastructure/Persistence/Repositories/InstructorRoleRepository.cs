using Domain.Instructors;
using Domain.Instructors.Repositories;
using Infrastructure.Persistence.EFC.Contexts;

namespace Infrastructure.Persistence.Repositories;

public sealed class InstructorRoleRepository
	: IInstructorRoleRepository
{
	private readonly CourseOnlineDbContext _context;

	public InstructorRoleRepository(CourseOnlineDbContext context)
	{
		_context = context;
	}

    public Task<InstructorRole> AddAsync(InstructorRole model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<InstructorRole>> GetAllAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<InstructorRole?> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<InstructorRole?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<InstructorRole?> GetByRoleNameAsync(string roleName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<InstructorRole?> UpdateAsync(int id, InstructorRole model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<InstructorRole?> UpdateAsync(Guid id, InstructorRole model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
