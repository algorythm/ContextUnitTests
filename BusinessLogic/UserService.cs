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

        /// <summary>
        /// Checks to see if the specified user already exists in the database.
        ///
        /// If the user exists, it returns that user right away
        /// If the user does not exist, it creates the user, then returns it
        /// </summary>
        /// <param name="user">The user to either fetch or create</param>
        /// <returns></returns>
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
