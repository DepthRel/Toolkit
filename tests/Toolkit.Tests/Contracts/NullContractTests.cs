using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
                var originalCheckedObject = Contract.NotNull<object, ArgumentNullException>(obj);
                Assert.IsTrue(ReferenceEquals(obj, originalCheckedObject));
            }
            catch (ArgumentException)
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
            catch (ArgumentNullException)
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
                var originalCheckedArray = Contract.NotNull<object, ArgumentNullException>(objs).ToArray();
                Assert.AreEqual(objs.Length, originalCheckedArray.Length);

                for (int i = 0; i < objs.Length; i++)
                {
                    Assert.IsTrue(ReferenceEquals(objs[i], originalCheckedArray[i]));
                }
            }
            catch (ArgumentNullException)
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
            catch (ArgumentNullException)
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
                var originalCheckedString = Contract.StringFilled<ArgumentException>(str);
                Assert.AreEqual(str, originalCheckedString);
            }
            catch (ArgumentException)
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
                Contract.StringFilled<ArgumentException>(str);
                Assert.Fail($"{nameof(ArgumentException)} expected");
            }
            catch (ArgumentException)
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