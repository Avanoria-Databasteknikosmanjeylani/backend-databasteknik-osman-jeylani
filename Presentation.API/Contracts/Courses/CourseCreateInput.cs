namespace Presentation.API.Contracts.Courses;

public sealed record CourseCreateInput(
	string Title,
	string Description,
	int Length
);
