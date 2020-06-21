using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Toolkit.Contracts;

namespace Toolkit.Tests.Contracts
{
    [TestClass]
    public class NullContractTests
    {
        [TestMethod]
        public void ObjectNotNullCorrect()
        {
            object obj = new object();

            try
            {
                Contract.NotNull<object, ArgumentNullException>(obj);
                Assert.AreEqual(0, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [TestMethod]
        public void ObjectNotNullInorrect()
        {
            object obj = null;

            try
            {
                Contract.NotNull<object, ArgumentNullException>(obj);
                Assert.Fail($"{nameof(ArgumentNullException)} expected");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
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

            try
            {
                Contract.NotNull<object, ArgumentNullException>(objs);
                Assert.AreEqual(0, 0);
            }
            catch (ArgumentNullException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
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

            try
            {
                Contract.NotNull<object, ArgumentNullException>(objs);
                Assert.Fail($"{nameof(ArgumentNullException)} expected");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [TestMethod]
        public void StringNotNullCorrect()
        {
            string str = "string";

            try
            {
                Contract.StringNotNullOrWhiteSpace<ArgumentException>(str);
                Assert.AreEqual(0, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [TestMethod]
        public void StringNotNullInorrect()
        {
            string str = "";

            try
            {
                Contract.StringNotNullOrWhiteSpace<ArgumentException>(str);
                Assert.Fail($"{nameof(ArgumentException)} expected");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(0, 0);
            }
            catch (Exception ex)
            {
                Assert.Fail($"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }
    }
}