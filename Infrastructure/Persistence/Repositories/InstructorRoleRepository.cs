using Domain.Instructors;
using Domain.Instructors.Repositories;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

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


	public async Task<InstructorRole?> GetByIdAsync(Guid id, CancellationToken ct)
	{
		var entity = await _context.InstructorRoles
			.FirstOrDefaultAsync(x => x.Id == id, ct);

		if (entity is null)
			return null;

		return new InstructorRole(
			entity.Id,
			entity.Name
		);
	}

	public async Task<InstructorRole?> GetByRoleNameAsync(string roleName, CancellationToken ct)
	{
		var entity = await _context.InstructorRoles
			.FirstOrDefaultAsync(x => x.Name == roleName, ct);

		if (entity is null)
			return null;

		return new InstructorRole(
			entity.Id,
			entity.Name
		);
	}



	public Task<bool> RemoveAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

  

    public Task<InstructorRole?> UpdateAsync(Guid id, InstructorRole model, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
