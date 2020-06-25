using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toolkit.Tests
{
    [TestClass]
    public class IntervalTests
    {
        [TestMethod]
        public void InitializeCorrect()
        {
            var interval = new Range<int>(10, 1);

            Assert.AreEqual(1, interval.Left);
            Assert.AreEqual(10, interval.Right);
        }

        [TestMethod]
        public void InsideCorrect()
        {
            var interval = new Range<int>(1, 10);
            bool result;

            result = interval.Inside(-1);
            Assert.AreEqual(false, result);

            result = interval.Inside(1);
            Assert.AreEqual(true, result);

            result = interval.Inside(5);
            Assert.AreEqual(true, result);

            result = interval.Inside(10);
            Assert.AreEqual(true, result);

            result = interval.Inside(12);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void BetweenCorrect()
        {
            var interval = new Range<int>(1, 10);
            bool result;

            result = interval.Between(-1);
            Assert.AreEqual(false, result);

            result = interval.Between(1);
            Assert.AreEqual(false, result);

            result = interval.Between(5);
            Assert.AreEqual(true, result);

            result = interval.Between(10);
            Assert.AreEqual(false, result);

            result = interval.Between(12);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void OutsideCorrect()
        {
            var interval = new Range<int>(1, 10);
            bool result;

            result = interval.Outside(-1);
            Assert.AreEqual(true, result);

            result = interval.Outside(1);
            Assert.AreEqual(false, result);

            result = interval.Outside(5);
            Assert.AreEqual(false, result);

            result = interval.Outside(10);
            Assert.AreEqual(false, result);

            result = interval.Outside(12);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void BeyondCorrect()
        {
            var interval = new Range<int>(1, 10);
            bool result;

            result = interval.Beyond(-1);
            Assert.AreEqual(false, result);

            result = interval.Beyond(1);
            Assert.AreEqual(false, result);

            result = interval.Beyond(5);
            Assert.AreEqual(false, result);

            result = interval.Beyond(10);
            Assert.AreEqual(false, result);

            result = interval.Beyond(12);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void BeforeCorrect()
        {
            var interval = new Range<int>(1, 10);
            bool result;

            result = interval.Before(-1);
            Assert.AreEqual(true, result);

            result = interval.Before(1);
            Assert.AreEqual(false, result);

            result = interval.Before(5);
            Assert.AreEqual(false, result);

            result = interval.Before(10);
            Assert.AreEqual(false, result);

            result = interval.Before(12);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void EqualsCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(1, 10);

            Assert.AreEqual(true, firstInterval.Equals(secondInterval));
            Assert.AreEqual(true, firstInterval == secondInterval);
            Assert.AreEqual(false, firstInterval != secondInterval);
        }

        [TestMethod]
        public void NotEqualsCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(-1, 10);

            Assert.AreEqual(false, firstInterval.Equals(secondInterval));
            Assert.AreEqual(false, firstInterval == secondInterval);
            Assert.AreEqual(true, firstInterval != secondInterval);
        }

        [TestMethod]
        public void EqualsHashCodeCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(1, 10);

            Assert.AreEqual(true, firstInterval.GetHashCode() == secondInterval.GetHashCode());
        }

        [TestMethod]
        public void NotEqualsHashCodeCorrect()
        {
            var firstInterval = new Range<int>(1, 10);
            var secondInterval = new Range<int>(-1, 10);

            Assert.AreEqual(false, firstInterval.GetHashCode() == secondInterval.GetHashCode());
        }
    }
}