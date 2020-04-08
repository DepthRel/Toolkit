using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolkit.Contracts;

namespace Toolkit.Tests.Contracts
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
        public void StringNotNullCorrect()
        {
            string str = "string";

            Assert.AreEqual(true, Check.StringNotNullOrWhiteSpace(str));
        }

        [TestMethod]
        public void StringNotNullInorrect()
        {
            string str = "";

            Assert.AreEqual(false, Check.StringNotNullOrWhiteSpace(str));
        }
    }
}