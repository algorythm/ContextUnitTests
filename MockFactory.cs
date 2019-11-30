using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ContextUnitTests
{
    public static class MockFactory
    {
        public static Mock<DbSet<T>> CreateDbSetMock<T>(params T[] list) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            var queryableList = list.AsQueryable();
            
            mockSet.As<IQueryable<T>>().Setup(mock => mock.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<T>>().Setup(mock => mock.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<T>>().Setup(mock => mock.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<T>>().Setup(mock => mock.GetEnumerator()).Returns(queryableList.GetEnumerator());

            return mockSet;
        }
    }
}
