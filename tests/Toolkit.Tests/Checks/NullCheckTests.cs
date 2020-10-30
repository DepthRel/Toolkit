using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolkit.Contracts;

namespace Toolkit.Tests.Checks
{
    [TestClass]
    public class NullCheckTests
    {
        [TestMethod]
        public void ObjectNotNullCorrect()
        {
            object obj = new object();

            Assert.AreEqual(true, Check.NotNull<object>(obj));
        }

        [TestMethod]
        public void ObjectNotNullInorrect()
        {
            object obj = null;

            Assert.AreEqual(false, Check.NotNull<object>(obj));
        }

        [TestMethod]
        public void ObjectsNotNullCorrect()
        {
            object[] objs = new object[]
            {
                new object(),
                new object(),
                new object(),
                new object()
            };

            Assert.AreEqual(true, Check.NotNull<object>(objs));
        }

        [TestMethod]
        public void ObjectsNotNullInorrect()
        {
            object[] objs = new object[]
            {
                new object(),
                new object(),
                null,
                new object()
            };

            Assert.AreEqual(false, Check.NotNull<object>(objs));
        }

        [TestMethod]
        public void StringFilledCorrect()
        {
            string str = "string";

            Assert.AreEqual(true, Check.StringFilled(str));
        }

        [TestMethod]
        public void StringFilledInorrect()
        {
            string str = "";

            Assert.AreEqual(false, Check.StringFilled(str));
        }

        [TestMethod]
        public void StringsFilledCorrect()
        {
            string str1 = "string";
            string str2 = " afas ";

            Assert.AreEqual(true, Check.StringFilled(str1, str2));
        }

        [TestMethod]
        public void StringsFilledInorrect()
        {
            string str1 = "string";
            string str2 = null;

            Assert.AreEqual(false, Check.StringFilled(str1, str2));
        }
    }
}