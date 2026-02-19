using Domain.Common.Base;

namespace Domain.Instructors.Repositories;

public interface IInstructorRoleRepository : IRepositoryBase<InstructorRole, int>
{
	Task<InstructorRole?> GetByRoleNameAsync(string roleName, CancellationToken ct);
}