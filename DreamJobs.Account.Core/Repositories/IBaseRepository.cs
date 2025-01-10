namespace DreamJobs.Account.Core.Repositories;

public interface IBaseRepository<T, K> where T : class where K : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T> UpdateAsync(K entity);
}