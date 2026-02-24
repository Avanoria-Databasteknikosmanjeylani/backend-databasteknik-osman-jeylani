using Domain.Common.Exceptions;

namespace Domain.Instructors;

public sealed class Instructor
{
	public Instructor(Guid id, string? firstName, string? lastName, string? email, string? phoneNumber, InstructorRole role)
	{
		if (id == Guid.Empty)
			throw new DomainValidationException("Id is required.");

		if (string.IsNullOrWhiteSpace(firstName))
			throw new DomainValidationException("FirstName is required.");

		if (string.IsNullOrWhiteSpace(lastName))
			throw new DomainValidationException("LastName is required.");

		if (string.IsNullOrWhiteSpace(email))
			throw new DomainValidationException("Email is required.");

		if (role is null)
			throw new DomainValidationException("Role is required.");

		Id = id;
		FirstName = firstName.Trim();
		LastName = lastName.Trim();
		Email = email.Trim();
		PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber.Trim();
		Role = role;
	}

	public Guid Id { get; }
	public string FirstName { get; private set; }
	public string LastName { get; private set; }
	public string Email { get; private set; }
	public string? PhoneNumber { get; private set; }
	public InstructorRole Role { get; private set; }
}