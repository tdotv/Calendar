using Calendar.Models;

namespace Calendar.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersNoTracking();
        Task<User> GetUserById(string id);
        bool Add(User user);
        bool Edit(User user);
        bool Delete(User user);
        bool Save();
    }
}