using Microsoft.EntityFrameworkCore;

namespace ContextUnitTests.BusinessLogic
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        //   One issue .NET will complain about is the fact that there is no parameterless constructor here
        //   Moq cannot instantiate a new ApplicationContext without a parameterless constructor. One might want to add
        // one, though doing that will result in another error, which can be difficult to find in the unit test. The
        // actual unit test might run fine, though if we have a WebApi that instantiates a new `ApplicationContext`
        // then there must only be a single public constructor, and that constructor **must** take `DbContextOptions`
        // as a parameter, unfortunately for us.
        
        public DbSet<User> Users { get; set; }
    }
}
