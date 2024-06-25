using Microsoft.EntityFrameworkCore;
using Calendar.Data;
using Calendar.Interfaces;
using Calendar.Models;

namespace Calendar.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public bool Edit(User user)
        {
            _context.Update(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAllUsers() => await _context.User.ToListAsync();

        public async Task<IEnumerable<User>> GetAllUsersNoTracking() =>  await _context.User.AsNoTracking().ToListAsync();

        public async Task<User> GetUserById(string id) => await _context.User.FindAsync(id) ?? throw new NullReferenceException();

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}