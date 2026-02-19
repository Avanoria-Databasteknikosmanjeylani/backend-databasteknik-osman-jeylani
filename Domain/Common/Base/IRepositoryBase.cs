namespace Domain.Common.Base;

public interface IRepositoryBase<TModel, TKey>
{
	Task<TModel> AddAsync(TModel model, CancellationToken ct);
	Task<TModel?> GetByIdAsync(TKey id, CancellationToken ct);
	Task<IReadOnlyList<TModel>> GetAllAsync(CancellationToken ct);
	Task<TModel?> UpdateAsync(TKey id, TModel model, CancellationToken ct);
	Task<bool> RemoveAsync(TKey id, CancellationToken ct);
}