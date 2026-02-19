using Application.Common.Results;
using Application.Instructors.Inputs;
using Domain.Instructors;

namespace Application.Instructors.Contracts;

public interface IInstructorRoleService
{
	Task<Result<InstructorRole?>> CreateInstructorRoleAsync(string roleName, CancellationToken ct);
	Task<Result<InstructorRole?>> GetInstructorRoleByAsync(int id, CancellationToken ct);
	Task<Result<IReadOnlyList<InstructorRole>>> GetInstructorRolesAsync(CancellationToken ct);
	Task<Result<InstructorRole?>> UpdateInstructorRoleByIdAsync(UpdateInstructorRoleInput input, CancellationToken ct);
	Task<Result> DeleteInstructorRoleAsync(int id, CancellationToken ct);
}
