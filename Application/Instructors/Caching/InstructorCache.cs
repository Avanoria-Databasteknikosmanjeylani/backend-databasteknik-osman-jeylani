using Application.Common.Caching;
using Domain.Instructors;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Instructors.Caching;

public sealed class InstructorCache(IMemoryCache cache) : CachedEntityBase<Instructor, string>(cache)
{
	protected override string Prefix => "instructors";
	protected override string GetId(Instructor entity) => entity.Id;

	protected override IEnumerable<(string Name, string Value)> GetIndexes(Instructor entity)
	{
		if (!string.IsNullOrWhiteSpace(entity.Email))
			yield return ("email", entity.Email);
	}

	public Task<Instructor?> GetByIdAsync(string id, Func<CancellationToken, Task<Instructor?>> factory, CancellationToken ct)
		=> GetOrCreateByIdAsync(id, factory, ct);

	public Task<Instructor?> GetByEmailAsync(string email, Func<CancellationToken, Task<Instructor?>> factory, CancellationToken ct)
		=> GetOrCreateByIndexAsync("email", email, factory, ct);

	public Task<IReadOnlyList<Instructor>?> GetAllAsync(Func<CancellationToken, Task<IReadOnlyList<Instructor>>> factory, CancellationToken ct)
		=> GetOrCreateAllAsync(factory, ct);
}