using Domain.Common.Base;

namespace Domain.Instructors.Repositories;

public interface IInstructorRepository : IRepositoryBase<Instructor, Guid>
{
	Task<Instructor?> GetByEmailAsync(string email, CancellationToken ct);
}