using Xunit;

namespace Toolkit.Tests
{
    public class ConditionTests
    {
        [Theory]
        [InlineData(10)]
        public void CheckTrueCorrect(int value)
        {
            Assert.True(Condition.Check(value == 10));
        }

        [Theory]
        [InlineData(20)]
        public void CheckFalseCorrect(int value)
        {
            Assert.False(Condition.Check(value == 10));
        }

        [Theory]
        [InlineData(10, 20)]
        public void AndChainTrueCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .And(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 30)]
        public void AndChainFalseCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .And(second == 20);

            Assert.False(result);
        }

        [Theory]
        [InlineData(10, 20)]
        public void OrChainTrueCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .Or(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 30)]
        public void OrChainFalseCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .Or(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 20)]
        public void AndNotChainTrueCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .AndNot(second == 20);

            Assert.False(result);
        }

        [Theory]
        [InlineData(10, 30)]
        public void AndNotChainFalseCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .AndNot(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 20)]
        public void OrNotChainTrueCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .OrNot(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10, 30)]
        public void OrNotChainFalseCorrect(int first, int second)
        {
            var result = Condition
                .Check(first == 10)
                .OrNot(second == 20);

            Assert.True(result);
        }

        [Theory]
        [InlineData(10)]
        public void NotChainTrueCorrect(int value)
        {
            var result = Condition.Check(value != 10).Not();

            Assert.True(result);
        }

        [Theory]
        [InlineData(10)]
        public void NotChainFalseCorrect(int value)
        {
            var result = Condition.Check(value == 10).Not();

            Assert.False(result);
        }
    }
}