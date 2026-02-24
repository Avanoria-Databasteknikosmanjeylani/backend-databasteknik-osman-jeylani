namespace Infrastructure.Persistence.Entities;

public sealed class CourseSessionEntity
{
	public Guid Id { get; set; }

	public Guid CourseId { get; set; }
	public CourseEntity Course { get; set; } = null!;

	public Guid InstructorId { get; set; }
	public InstructorEntity Instructor { get; set; } = null!;

	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }

	public int MaxParticipants { get; set; }

	public ICollection<CourseRegistrationEntity> Registrations { get; set; } = new List<CourseRegistrationEntity>();
}
