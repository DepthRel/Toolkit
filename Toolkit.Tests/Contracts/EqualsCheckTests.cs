using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Toolkit.Contracts;

namespace Toolkit.Tests.Contracts
{
    [TestClass]
    public class EqualsChecks
    {
        [TestMethod]
        public void EqualCorrect()
        {
            int first = 5;
            int second = 5;

            try
            {
                Contract.Equal<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void EqualIncorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.Equal<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotEqualCorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.NotEqual<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotEqualIncorrect()
        {
            int first = 5;
            int second = 5;

            try
            {
                Contract.NotEqual<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void MoreOrEqualThanCorrect()
        {
            int first = 5;
            int second = 5;
            int third = 0;

            try
            {
                Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
                Contract.MoreOrEqualThan<int, InvalidOperationException>(first, third);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void MoreOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void MoreThanCorrect()
        {
            int first = 5;
            int second = 0;

            try
            {
                Contract.MoreThan<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void MoreThanIncorrect()
        {
            int first = 5;
            int second = 5;

            try
            {
                Contract.MoreThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotMoreOrEqualThanCorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.NotMoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotMoreOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 0;

            try
            {
                Contract.NotMoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void LessOrEqualThanCorrect()
        {
            int first = 5;
            int second = 5;
            int third = 10;

            try
            {
                Contract.LessOrEqualThan<int, InvalidOperationException>(first, second);
                Contract.LessOrEqualThan<int, InvalidOperationException>(first, third);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void LessOrEqualThanIncorrect()
        {
            int first = 5;
            int second = -5;

            try
            {
                Contract.LessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void LessThanCorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.LessThan<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void LessThanIncorrect()
        {
            int first = 5;
            int second = 5;

            try
            {
                Contract.LessThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotLessOrEqualThanCorrect()
        {
            int first = 5;
            int second = 0;

            try
            {
                Contract.NotLessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.AreEqual(0, 0);
            }
            catch (InvalidOperationException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [TestMethod]
        public void NotLessOrEqualThanIncorrect()
        {
            int first = 5;
            int second = 10;

            try
            {
                Contract.NotLessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.Fail($"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }
    }
}