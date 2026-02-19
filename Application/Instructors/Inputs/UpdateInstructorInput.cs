namespace Application.Instructors.Inputs;

public sealed record UpdateInstructorInput
(
	string Id,
	string FirstName,
	string LastName,
	string Email,
	string? PhoneNumber
);
