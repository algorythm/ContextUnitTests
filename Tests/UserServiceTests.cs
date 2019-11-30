using System;
using System.Threading;
using System.Threading.Tasks;
using ContextUnitTests.BusinessLogic;
using Moq;
using Xunit;

namespace ContextUnitTests.Tests
{
    public class UserServiceTests : BaseTest
    {
        /// <summary>
        /// This should test if the context's AddAsync is called when UserService.GetOrCreate(...) is called, where
        /// the user have already been added to the database
        /// </summary>
        [Fact]
        public async Task GetOrCreate_DoesNotCreateUser_WhenUserExists()
        {
            var user = new User { Id = Guid.NewGuid().ToString(), Name = "John Doe"};

            await using (var context = new ApplicationContext(Options))
            {
                await context.AddAsync(user);
                await context.SaveChangesAsync();
            }

            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(m => m.Set<User>()).Returns(MockFactory.CreateDbSetMock(user).Object);
            
            var userService = new UserService(mockContext.Object);
            await userService.GetOrCreateUser(user);
            
            mockContext.Verify(m => m.Users.AddAsync(
                It.IsAny<User>(), 
                It.IsAny<CancellationToken>()
            ), Times.Never);
        }
    }
}
