using appointmentapi.Data;
using appointmentapi.Models;
using appointmentapi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace appointmentapi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<User> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .AsNoTracking().
            FirstOrDefaultAsync(u => u.Username == username);
    }
}
