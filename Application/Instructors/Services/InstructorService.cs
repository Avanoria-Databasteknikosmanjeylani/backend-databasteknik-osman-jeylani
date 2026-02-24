using Application.Common.Results;
using Application.Extensions.Caching;
using Application.Instructors.Caching;
using Application.Instructors.Contracts;
using Application.Instructors.Factories;
using Application.Instructors.Inputs;
using Domain.Instructors;
using Domain.Instructors.Repositories;

namespace Application.Instructors.Services;

public sealed class InstructorService(InstructorCache cache, IInstructorRepository instructorRepo, IInstructorRoleRepository roleRepo) : IInstructorService
{
	public async Task<Result<Instructor?>> CreateInstructorAsync(CreateInstructorInput input, CancellationToken ct)
	{
		if (string.IsNullOrWhiteSpace(input.Email))
			return Result<Instructor?>.BadRequest($"{nameof(input.Email)} is required");

		var existing = await cache.GetByEmailAsync(
			input.Email,
			token => instructorRepo.GetByEmailAsync(input.Email, token),
			ct);

		if (existing is not null)
			return Result<Instructor?>.Conflict("An instructor with the same email address already exists.");

		var role = await roleRepo.GetByIdAsync(input.RoleId, ct);
		if (role is null)
			return Result<Instructor?>.NotFound("Instructor role was not found.");

		var instructor = InstructorFactory.Create(input, role);

		var created = await instructorRepo.AddAsync(instructor, ct);
		if (created is null)
			return Result<Instructor?>.Error("Instructor was not created.");

		cache.ResetEntity(created);
		cache.SetEntity(created);

		return Result<Instructor?>.Ok(created);

	}

    public Task<Result> DeleteInstructorAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Instructor?>> GetInstructorByEmailAsync(string email, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Instructor?>> GetInstructorByIdAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Instructor>> GetInstructorsAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Instructor?>> UpdateInstructorAsync(UpdateInstructorInput input, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}