using NuGet.Frameworks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void TestFail()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void MyFirstTheory(int x)
        {
            Assert.True(IsOdd(x));
        }

        bool IsOdd(int x)
        {
            return x % 2 == 1;
        }
    }
}