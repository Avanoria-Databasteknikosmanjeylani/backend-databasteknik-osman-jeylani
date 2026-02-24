using Domain.Common.Base;

namespace Domain.Instructors.Repositories;

public interface IInstructorRoleRepository : IRepositoryBase<InstructorRole, Guid>
{
	Task<InstructorRole?> GetByRoleNameAsync(string roleName, CancellationToken ct);
}