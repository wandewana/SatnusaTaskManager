using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid userId);
    Task AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
