namespace Infrastructure.Persistence.Entities;

public sealed class CourseEntity
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public int Length { get; set; }

	public ICollection<CourseSessionEntity> Sessions { get; set; } = new List<CourseSessionEntity>();
}
