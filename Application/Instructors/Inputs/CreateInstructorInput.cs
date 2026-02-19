namespace Application.Instructors.Inputs;

public sealed record CreateInstructorInput
(
	string FirstName,
	string LastName,
	string Email,
	string? PhoneNumber,
	int RoleId

);
