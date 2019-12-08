using Ganache.API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ganache.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserInfo(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username); //Get user from database.
            if (user == null)
                return null; // User does not exist.
            return user;
        }


    }
}