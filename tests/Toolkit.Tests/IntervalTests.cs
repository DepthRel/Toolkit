using Xunit;

namespace Toolkit.Tests
{
    public class IntervalTests
    {
        [Theory]
        [InlineData(10, 1)]
        public void InitializeCorrect(in int first, in int second)
        {
            var interval = new Range<int>(first, second);

            Assert.Equal(second, interval.Left);
            Assert.Equal(first, interval.Right);
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(10, true)]
        [InlineData(12, false)]
        public void InsideCorrect(in int value, in bool result)
        {
            var interval = new Range<int>(1, 10);

            Assert.Equal(result, interval.Inside(value));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        [InlineData(12, false)]
        public void BetweenCorrect(in int value, in bool result)
        {
            var interval = new Range<int>(1, 10);

            Assert.Equal(result, interval.Between(value));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(1, false)]
        [InlineData(5, false)]
        [InlineData(10, false)]
        [InlineData(12, true)]
        public void OutsideCorrect(in int value, in bool result)
        {
            var interval = new Range<int>(1, 10);

            Assert.Equal(result, interval.Outside(value));
        }

        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, false)]
        [InlineData(5, false)]
        [InlineData(10, false)]
        [InlineData(12, true)]
        public void BeyondCorrect(in int value, in bool result)
        {
            var interval = new Range<int>(1, 10);

            Assert.Equal(result, interval.Beyond(value));
        }

        [Theory]
        [InlineData(-1, true)]
        [InlineData(1, false)]
        [InlineData(5, false)]
        [InlineData(10, false)]
        [InlineData(12, false)]
        public void BeforeCorrect(in int value, in bool result)
        {
            var interval = new Range<int>(1, 10);

            Assert.Equal(result, interval.Before(value));
        }

        [Fact]
        public void EqualsCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(1, 10);

            Assert.True(firstInterval.Equals(secondInterval));
            Assert.True(firstInterval == secondInterval);
            Assert.False(firstInterval != secondInterval);
        }

        [Fact]
        public void EqualsWithNullCorrect()
        {
            Range<int> firstInterval = new Range<int>(1, 10);
            Range<int> secondInterval = null;

            Assert.False(firstInterval.Equals(secondInterval));
            Assert.False(firstInterval == secondInterval);
            Assert.True(firstInterval != secondInterval);
        }

        [Fact]
        public void NotEqualsCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(-1, 10);

            Assert.False(firstInterval.Equals(secondInterval));
            Assert.False(firstInterval == secondInterval);
            Assert.True(firstInterval != secondInterval);
        }

        [Fact]
        public void EqualsHashCodeCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(1, 10);

            Assert.True(firstInterval.GetHashCode() == secondInterval.GetHashCode());
        }

        [Fact]
        public void NotEqualsHashCodeCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(-1, 10);

            Assert.False(firstInterval.GetHashCode() == secondInterval.GetHashCode());
        }
    }
}