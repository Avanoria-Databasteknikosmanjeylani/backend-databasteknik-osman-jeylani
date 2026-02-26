using Application.Instructors.Inputs;
using Domain.Instructors;

namespace Application.Instructors.Factories;

public static class InstructorFactory
{
	public static Instructor Create(CreateInstructorInput input, InstructorRole role)
		=> new
		(
			Guid.NewGuid(),
			input.FirstName,
			input.LastName,
			input.Email,
			input.PhoneNumber,
			role
		);
}