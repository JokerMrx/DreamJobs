namespace DreamJobs.Account.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T> UpdateAsync(T entity);
}