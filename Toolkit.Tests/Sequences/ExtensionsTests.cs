using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolkit.Sequences;
using System.Collections.Generic;
using System.Linq;

namespace Toolkit.Tests.Sequences
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void ReorderTestCorrect()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var reorderedList = Extensions.Reorder(list).ToList();

            Assert.AreEqual(list.Count, reorderedList.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != reorderedList[i])
                {
                    Assert.AreEqual(0, 0);
                    return;
                }
            }

            Assert.Fail();
        }

        [TestMethod]
        public void ReorderExtensionTestCorrect()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var reorderedList = list.Reorder().ToList();

            Assert.AreEqual(list.Count, reorderedList.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != reorderedList[i])
                {
                    Assert.AreEqual(0, 0);
                    return;
                }
            }

            Assert.Fail();
        }

        [TestMethod]
        public void SwapExtensionWithIntValuesTestCorrect()
        {
            int first = 1;
            int firstOld = first;

            int second = 20;
            int secondOld = second;

            Extensions.Swap(ref first, ref second);

            Assert.AreEqual(secondOld, first);
            Assert.AreEqual(firstOld, second);
        }

        [TestMethod]
        public void SwapExtensionWithStringValuesTestCorrect()
        {
            string first = "1";
            string firstOld = first;

            string second = "20";
            string secondOld = second;

            Extensions.Swap(ref first, ref second);

            Assert.AreEqual(secondOld, first);
            Assert.AreEqual(firstOld, second);
        }
    }
}