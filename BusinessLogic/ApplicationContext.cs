using Microsoft.EntityFrameworkCore;

namespace ContextUnitTests.BusinessLogic
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
