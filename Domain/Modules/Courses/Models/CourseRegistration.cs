namespace Domain.Modules.Courses.Models;

public sealed class CourseRegistration
{
	public Guid Id { get; }
	public Guid CourseSessionId { get; }
	public Guid ParticipantId { get; }
	public DateTime RegisteredAt { get; }

	public CourseRegistration(
		Guid id,
		Guid courseSessionId,
		Guid participantId,
		DateTime registeredAt)
	{
		if (id == Guid.Empty)
			throw new ArgumentException("Registration id cannot be empty.");

		if (courseSessionId == Guid.Empty)
			throw new ArgumentException("CourseSessionId cannot be empty.");

		if (participantId == Guid.Empty)
			throw new ArgumentException("ParticipantId cannot be empty.");

		Id = id;
		CourseSessionId = courseSessionId;
		ParticipantId = participantId;
		RegisteredAt = registeredAt;
	}
}