using System;
using ContextUnitTests.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ContextUnitTests
{
    public class BaseTest
    {
        protected readonly DbContextOptions<ApplicationContext> Options;

        public BaseTest()
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }
    }
}