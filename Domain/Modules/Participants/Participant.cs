namespace Domain.Modules.Participants;

public sealed class Participant
{
	public Guid Id { get; }
	public string FirstName { get; }
	public string LastName { get; }
	public string Email { get; }

	public Participant(Guid id, string firstName, string lastName, string email)
	{
		if (id == Guid.Empty)
			throw new ArgumentException("Participant id cannot be empty.");

		if (string.IsNullOrWhiteSpace(firstName))
			throw new ArgumentException("First name cannot be empty.");

		if (string.IsNullOrWhiteSpace(lastName))
			throw new ArgumentException("Last name cannot be empty.");

		if (string.IsNullOrWhiteSpace(email))
			throw new ArgumentException("Email cannot be empty.");

		Id = id;
		FirstName = firstName.Trim();
		LastName = lastName.Trim();
		Email = email.Trim().ToLower();
	}
}