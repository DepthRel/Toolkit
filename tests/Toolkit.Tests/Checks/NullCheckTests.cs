using Toolkit.Contracts;
using Xunit;

namespace Toolkit.Tests.Checks
{
    public class NullCheckTests
    {
        [Fact]
        public void ObjectNotNullCorrect()
        {
            object obj = new object();

            Assert.True(Check.NotNull<object>(obj));
        }

        [Fact]
        public void ObjectNotNullInorrect()
        {
            object obj = null;

            Assert.False(Check.NotNull<object>(obj));
        }

        [Fact]
        public void ObjectsNotNullCorrect()
        {
            object[] objs = new object[]
            {
                new object(),
                new object(),
                new object(),
                new object()
            };

            Assert.True(Check.NotNull<object>(objs));
        }

        [Fact]
        public void ObjectsNotNullInorrect()
        {
            object[] objs = new object[]
            {
                new object(),
                new object(),
                null,
                new object()
            };

            Assert.False(Check.NotNull<object>(objs));
        }

        [Fact]
        public void StringFilledCorrect()
        {
            string str = "string";

            Assert.True(Check.StringFilled(str));
        }

        [Theory]
        [InlineData("")]
        public void StringFilledInorrect(string line)
        {
            Assert.False(Check.StringFilled(line));
        }

        [Theory]
        [InlineData("string", " afas ")]
        public void StringsFilledCorrect(string str1, string str2)
        {
            Assert.True(Check.StringFilled(str1, str2));
        }

        [Theory]
        [InlineData("string", null)]
        [InlineData(null, "string")]
        public void StringsFilledInorrect(string str1, string str2)
        {
            Assert.False(Check.StringFilled(str1, str2));
        }
    }
}