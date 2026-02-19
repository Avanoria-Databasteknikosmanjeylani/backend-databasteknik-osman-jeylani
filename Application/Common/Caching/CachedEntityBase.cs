using Microsoft.Extensions.Caching.Memory;
using Application.Extensions.Caching;

namespace Application.Common.Caching;

public abstract class CachedEntityBase<TEntity, TId>(IMemoryCache cache)
{
	protected abstract string Prefix { get; }
	protected abstract TId GetId(TEntity entity);
	protected virtual IEnumerable<(string Name, string Value)> GetIndexes(TEntity entity) => [];
	protected virtual string NormalizeIndexValue(string value) => value.Trim().ToLowerInvariant();

	protected virtual MemoryCacheEntryOptions EntityOptions => new()
	{
		AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
		SlidingExpiration = TimeSpan.FromMinutes(2),
	};

	protected virtual MemoryCacheEntryOptions ListOptions => new()
	{
		AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
		SlidingExpiration = TimeSpan.FromSeconds(10),
	};

	protected string IdKey(TId id) => $"{Prefix}:id:{id}";
	protected string IndexKey(string indexName, string indexValue) => $"{Prefix}:{indexName}:{indexValue}";
	protected string AllKey => $"{Prefix}:all";

	public void SetEntity(TEntity entity)
	{
		cache.Set(IdKey(GetId(entity)), entity, EntityOptions);

		foreach (var (name, value) in GetIndexes(entity))
		{
			if (string.IsNullOrWhiteSpace(value))
				continue;

			var normalized = NormalizeIndexValue(value);
			cache.Set(IndexKey(name, normalized), entity, EntityOptions);
		}
	}

	public void ResetEntity(TEntity entity)
	{
		cache.Remove(IdKey(GetId(entity)));

		foreach (var (name, value) in GetIndexes(entity))
		{
			if (string.IsNullOrWhiteSpace(value))
				continue;

			var normalized = NormalizeIndexValue(value);
			cache.Remove(IndexKey(name, normalized));
		}

		cache.Remove(AllKey);
	}

	public Task<TEntity?> GetOrCreateByIdAsync(TId id, Func<CancellationToken, Task<TEntity?>> factory, CancellationToken ct)
		=> cache.GetOrCreateAsync(
			IdKey(id),
			async (entry, token) =>
			{
				entry.SetOptions(EntityOptions);
				return await factory(token);
			}, ct);

	public Task<TEntity?> GetOrCreateByIndexAsync(string indexName, string indexValue, Func<CancellationToken, Task<TEntity?>> factory, CancellationToken ct)
	{
		var normalized = NormalizeIndexValue(indexValue);

		return cache.GetOrCreateAsync(
			IndexKey(indexName, normalized),
			async (entry, token) =>
			{
				entry.SetOptions(EntityOptions);
				return await factory(token);
			},
			ct);
	}

	public Task<IReadOnlyList<TEntity>?> GetOrCreateAllAsync(
		Func<CancellationToken, Task<IReadOnlyList<TEntity>>> factory,
		CancellationToken ct)
        => cache.GetOrCreateAsync(
			AllKey,
			async (entry, token) =>
			{
				entry.SetOptions(ListOptions);
				return await factory(token);
			},
			ct) ?? Task.FromResult<IReadOnlyList<TEntity>?>([]);
}