using appointmentapi.Models;
using appointmentapi.Repositories.Interface;
using System.Security.Cryptography;
using System.Text;

namespace appointmentapi.Services;

public class UserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(Person person, string password)
    {
        string passwordHash; 
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            passwordHash = Convert.ToBase64String(hash);
        }

        var user = new User
        {
            CdPerson = person.CdPerson,
            Username = person.Email,
            PasswordHash = passwordHash,
            FlAtivo = true
        };

        await _userRepository.AddUserAsync(user);
        return user;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
       var user = await _userRepository.GetUserByUsernameAsync(username);

        if (user is null)
            return null;

        string passwordHash;
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            passwordHash = Convert.ToBase64String(hash);
        }

        if (user.PasswordHash != passwordHash)
            return null;

        return user;
    }
}
