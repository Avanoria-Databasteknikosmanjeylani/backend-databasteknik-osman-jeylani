namespace Domain.Modules.Courses.Repositories;

using Domain.Modules.Courses.Models;

public interface ICourseRepository
{
	Task<Course?> GetByIdAsync(Guid id, CancellationToken ct);
	Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken ct);
	Task AddAsync(Course course, CancellationToken ct);
	Task<bool> UpdateAsync(Course course, CancellationToken ct);
	Task<bool> DeleteAsync(Guid id, CancellationToken ct);

}
