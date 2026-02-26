namespace Infrastructure.Persistence.Entities;

public class InstructorEntity
{
	public Guid Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set;} = null!;
	public string Email { get; set; } = null!;

	public Guid RoleId { get; set; }
	public InstructorRoleEntity Role { get; set; } = null!;
}
