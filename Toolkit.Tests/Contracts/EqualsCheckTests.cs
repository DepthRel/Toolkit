using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolkit.Contracts;

namespace Toolkit.Tests.Contracts
{
    [TestClass]
    public class EqualsCheckTests
    {
        [TestMethod]
        public void EqualCorrect()
        {
            int first = 5;
            int second = 5;

            Assert.AreEqual(true, Check.Equal(first, second));
        }

        [TestMethod]
        public void EqualIncorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(false, Check.Equal(first, second));
        }

        [TestMethod]
        public void NotEqualCorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(true, Check.NotEqual(first, second));
        }

        [TestMethod]
        public void NotEqualIncorrect()
        {
            int first = 5;
            int second = 5;

            Assert.AreEqual(false, Check.NotEqual(first, second));
        }

        [TestMethod]
        public void MoreOrEqualThanCorrect()
        {
            int first = 5;
            int second = 5;
            int third = 0;

            Assert.AreEqual(true, Check.MoreOrEqualThan(first, second));
            Assert.AreEqual(true, Check.MoreOrEqualThan(first, third));
        }

        [TestMethod]
        public void MoreOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(false, Check.MoreOrEqualThan(first, second));
        }

        [TestMethod]
        public void MoreThanCorrect()
        {
            int first = 5;
            int second = 0;

            Assert.AreEqual(true, Check.MoreThan(first, second));
        }

        [TestMethod]
        public void MoreThanIncorrect()
        {
            int first = 5;
            int second = 5;

            Assert.AreEqual(false, Check.MoreThan(first, second));
        }

        [TestMethod]
        public void NotMoreOrEqualThanCorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(true, Check.NotMoreOrEqualThan(first, second));
        }

        [TestMethod]
        public void NotMoreOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 0;

            Assert.AreEqual(false, Check.NotMoreOrEqualThan(first, second));
        }

        [TestMethod]
        public void LessOrEqualThanCorrect()
        {
            int first = 5;
            int second = 5;
            int third = 10;

            Assert.AreEqual(true, Check.LessOrEqualThan(first, second));
            Assert.AreEqual(true, Check.LessOrEqualThan(first, third));
        }

        [TestMethod]
        public void LessOrEqualThanIncorrect()
        {
            int first = 5;
            int second = -5;

            Assert.AreEqual(false, Check.LessOrEqualThan(first, second));
        }

        [TestMethod]
        public void LessThanCorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(true, Check.LessThan(first, second));
        }

        [TestMethod]
        public void LessThanIncorrect()
        {
            int first = 5;
            int second = 5;

            Assert.AreEqual(false, Check.LessThan(first, second));
        }

        [TestMethod]
        public void NotLessOrEqualThanCorrect()
        {
            int first = 5;
            int second = 0;

            Assert.AreEqual(true, Check.NotLessOrEqualThan(first, second));
        }

        [TestMethod]
        public void NotLessOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 10;

            Assert.AreEqual(false, Check.NotLessOrEqualThan(first, second));
        }
    }
}