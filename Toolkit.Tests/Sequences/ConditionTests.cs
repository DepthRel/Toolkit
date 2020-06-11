using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toolkit.Sequences;

namespace Toolkit.Tests.Sequences
{
    [TestClass]
    public class ConditionTests
    {
        [TestMethod]
        public void CheckTrueCorrect()
        {
            int a = 10;
            var result = Condition.Check(a == 10);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CheckFalseCorrect()
        {
            int a = 20;
            var result = Condition.Check(a == 10);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AndChainTrueCorrect()
        {
            int a = 10;
            int b = 20;
            var result = Condition
                .Check(a == 10)
                .And(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AndChainFalseCorrect()
        {
            int a = 10;
            int b = 30;
            var result = Condition
                .Check(a == 10)
                .And(b == 20);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void OrChainTrueCorrect()
        {
            int a = 10;
            int b = 20;
            var result = Condition
                .Check(a == 10)
                .Or(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OrChainFalseCorrect()
        {
            int a = 10;
            int b = 30;
            var result = Condition
                .Check(a == 10)
                .Or(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AndNotChainTrueCorrect()
        {
            int a = 10;
            int b = 20;
            var result = Condition
                .Check(a == 10)
                .AndNot(b == 20);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AndNotChainFalseCorrect()
        {
            int a = 10;
            int b = 30;
            var result = Condition
                .Check(a == 10)
                .AndNot(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OrNotChainTrueCorrect()
        {
            int a = 10;
            int b = 20;
            var result = Condition
                .Check(a == 10)
                .OrNot(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OrNotChainFalseCorrect()
        {
            int a = 10;
            int b = 30;
            var result = Condition
                .Check(a == 10)
                .OrNot(b == 20);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotChainTrueCorrect()
        {
            int a = 10;
            var result = Condition.Check(a != 10).Not();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NotChainFalseCorrect()
        {
            int a = 10;
            var result = Condition.Check(a == 10).Not();

            Assert.AreEqual(false, result);
        }
    }
}