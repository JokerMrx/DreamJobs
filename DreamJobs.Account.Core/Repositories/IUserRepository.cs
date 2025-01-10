using DreamJobs.Account.Core.Models;

namespace DreamJobs.Account.Core.Repositories;

public interface IUserRepository : IBaseRepository<User, User>
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetByEmailAsync(string email);
    public Task<User> ChangePasswordAsync(Guid employerId, string oldPassword, string newPassword);
    public Task<User> DeleteAsync(Guid id);
}