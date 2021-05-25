using Toolkit.Sequences;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Toolkit.Tests.Sequences
{
    public class ExtensionsTests
    {
        [Fact]
        public void ReorderTestCorrect()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var reorderedList = Extensions.Reorder(list).ToList();

            Assert.Equal(list.Count, reorderedList.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != reorderedList[i])
                {
                    Assert.True(true);
                    return;
                }
            }

            Assert.False(true);
        }

        [Fact]
        public void ReorderExtensionTestCorrect()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var reorderedList = list.Reorder().ToList();

            Assert.Equal(list.Count, reorderedList.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != reorderedList[i])
                {
                    Assert.True(true);
                    return;
                }
            }

            Assert.False(true);
        }

        [Fact]
        public void SwapExtensionWithIntValuesTestCorrect()
        {
            int first = 1;
            int firstOld = first;

            int second = 20;
            int secondOld = second;

            Extensions.Swap(ref first, ref second);

            Assert.Equal(secondOld, first);
            Assert.Equal(firstOld, second);
        }

        [Fact]
        public void SwapExtensionWithStringValuesTestCorrect()
        {
            string first = "1";
            string firstOld = first;

            string second = "20";
            string secondOld = second;

            Extensions.Swap(ref first, ref second);

            Assert.Equal(secondOld, first);
            Assert.Equal(firstOld, second);
        }

        [Theory]
        [InlineData("Filled string")]
        public void StringFilledTestCorrect(string line)
        {
            Assert.True(line.Filled());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        public void StringFilledWithNullOrWhiteSpacesIncorrectTestCorrect(string line)
        {
            Assert.False(line.Filled());
        }
    }
}