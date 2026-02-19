using Domain.Common.Base;

namespace Domain.Instructors.Repositories;

public interface IInstructorRepository : IRepositoryBase<Instructor, string>
{
	Task<Instructor?> GetByEmailAsync(string email, CancellationToken ct);
}