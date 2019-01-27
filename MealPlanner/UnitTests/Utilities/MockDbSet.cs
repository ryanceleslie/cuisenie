using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace UnitTests.Utilities
{
    [ExcludeFromCodeCoverage]
    public class MockDbSet<T> where T : class
    {
        public DbSet<T> Object { get; }

        public MockDbSet(IEnumerable<T> list)
        {
            var queryableList = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<T>(queryableList.GetEnumerator()));

            mockDbSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(queryableList.Provider));

            mockDbSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            Object = mockDbSet.Object;
        }
    }
}
