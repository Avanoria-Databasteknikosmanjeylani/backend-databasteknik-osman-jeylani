namespace Infrastructure.Persistence.Entities;

public sealed class CourseRegistrationEntity
{
	public Guid Id { get; set; }

	public Guid CourseSessionId { get; set; }
	public CourseSessionEntity CourseSession { get; set; } = null!;

	public Guid ParticipantId { get; set; }
	public ParticipantEntity Participant { get; set; } = null!;

	public DateTime RegisteredAt { get; set; }
}
