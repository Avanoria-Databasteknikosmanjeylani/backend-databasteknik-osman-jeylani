using Domain.Common.Exceptions;

namespace Domain.Instructors;

public sealed class InstructorRole
{
	public InstructorRole(string roleName)
	{
		if (string.IsNullOrWhiteSpace(roleName))
			throw new DomainValidationException("RoleName is required.");

		RoleName = roleName.Trim();
	}

	public InstructorRole(int id, string roleName)
	{
		if (id < 1)
			throw new DomainValidationException("Id is required.");

		if (string.IsNullOrWhiteSpace(roleName))
			throw new DomainValidationException("RoleName is required.");

		Id = id;
		RoleName = roleName.Trim();
	}

	public int Id { get; }
	public string RoleName { get; set; } = string.Empty;

}