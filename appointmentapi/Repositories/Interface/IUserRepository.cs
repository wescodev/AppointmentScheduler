using appointmentapi.Models;

namespace appointmentapi.Repositories.Interface;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
}
