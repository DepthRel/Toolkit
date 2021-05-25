using Toolkit.Contracts;
using Xunit;

namespace Toolkit.Tests.Checks
{
    public class EqualsCheckTests
    {
        [Theory]
        [InlineData(5, 5)]
        public void EqualCorrect(int first, int second)
        {
            Assert.True(Check.Equal(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void EqualIncorrect(int first, int second)
        {
            Assert.False(Check.Equal(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotEqualCorrect(int first, int second)
        {
            Assert.True(Check.NotEqual(first, second));
        }

        [Theory]
        [InlineData(5, 5)]
        public void NotEqualIncorrect(int first, int second)
        {
            Assert.False(Check.NotEqual(first, second));
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 0)]
        public void MoreOrEqualThanCorrect(int first, int second)
        {
            Assert.True(Check.MoreOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void MoreOrEqualThanIncorrect(int first, int second)
        {
            Assert.False(Check.MoreOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 0)]
        public void MoreThanCorrect(int first, int second)
        {
            Assert.True(Check.MoreThan(first, second));
        }

        [Theory]
        [InlineData(5, 5)]
        public void MoreThanIncorrect(int first, int second)
        {
            Assert.False(Check.MoreThan(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotMoreOrEqualThanCorrect(int first, int second)
        {
            Assert.True(Check.NotMoreOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 0)]
        public void NotMoreOrEqualThanIncorrect(int first, int second)
        {
            Assert.False(Check.NotMoreOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 10)]
        public void LessOrEqualThanCorrect(int first, int second)
        {
            Assert.True(Check.LessOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, -5)]
        public void LessOrEqualThanIncorrect(int first, int second)
        {
            Assert.False(Check.LessOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void LessThanCorrect(int first, int second)
        {
            Assert.True(Check.LessThan(first, second));
        }

        [Theory]
        [InlineData(5, 5)]
        public void LessThanIncorrect(int first, int second)
        {
            Assert.False(Check.LessThan(first, second));
        }

        [Theory]
        [InlineData(5, 0)]
        public void NotLessOrEqualThanCorrect(int first, int second)
        {
            Assert.True(Check.NotLessOrEqualThan(first, second));
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotLessOrEqualThanIncorrect(int first, int second)
        {
            Assert.False(Check.NotLessOrEqualThan(first, second));
        }
    }
}