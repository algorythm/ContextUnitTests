using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContextUnitTests.BusinessLogic
{
    public class UserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByName(string name) =>
            await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
        
        public async Task<User> GetOrCreateUser(User user)
        {
            var existingUser = await GetUserByName(user.Name);

            if (existingUser != null) return existingUser;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
