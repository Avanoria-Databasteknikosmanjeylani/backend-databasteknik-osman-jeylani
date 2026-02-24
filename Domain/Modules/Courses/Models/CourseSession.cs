namespace Domain.Modules.Courses.Models;

public sealed class CourseSession
{
	public Guid Id { get; }
	public Guid CourseId { get; }
	public Guid InstructorId { get; }
	public DateTime StartDate { get; }
	public DateTime EndDate { get; }
	public int MaxParticipants { get; }

	public CourseSession(
		Guid id,
		Guid courseId,
		Guid instructorId,
		DateTime startDate,
		DateTime endDate,
		int maxParticipants)
	{
		if (id == Guid.Empty)
			throw new ArgumentException("Session id cannot be empty.");

		if (courseId == Guid.Empty)
			throw new ArgumentException("CourseId cannot be empty.");

		if (instructorId == Guid.Empty)
			throw new ArgumentException("InstructorId cannot be empty.");

		if (endDate <= startDate)
			throw new ArgumentException("End date must be after start date.");

		if (maxParticipants <= 0)
			throw new ArgumentOutOfRangeException(nameof(maxParticipants));

		Id = id;
		CourseId = courseId;
		InstructorId = instructorId;
		StartDate = startDate;
		EndDate = endDate;
		MaxParticipants = maxParticipants;
	}
}

