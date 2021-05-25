using System;
using System.Linq;
using Toolkit.Contracts;
using Xunit;

namespace Toolkit.Tests.Contracts
{
    public class NullContractTests
    {
        [Fact]
        public void ObjectNotNullCorrect()
        {
            object obj = new object();

            try
            {
                var originalCheckedObject = Contract.NotNull<object, ArgumentNullException>(obj);
                Assert.True(ReferenceEquals(obj, originalCheckedObject));
            }
            catch (ArgumentException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [Fact]
        public void ObjectNotNullInorrect()
        {
            object obj = null;

            try
            {
                Contract.NotNull<object, ArgumentNullException>(obj);
                Assert.False(true, $"{nameof(ArgumentNullException)} expected");
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [Fact]
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
                Assert.Equal(objs.Length, originalCheckedArray.Length);

                for (int i = 0; i < objs.Length; i++)
                {
                    Assert.True(ReferenceEquals(objs[i], originalCheckedArray[i]));
                }
            }
            catch (ArgumentNullException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [Fact]
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
                Assert.False(true, $"{nameof(ArgumentNullException)} expected");
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [Fact]
        public void StringNotNullCorrect()
        {
            string str = "string";

            try
            {
                var originalCheckedString = Contract.StringFilled<ArgumentException>(str);
                Assert.Equal(str, originalCheckedString);
            }
            catch (ArgumentException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }

        [Fact]
        public void StringNotNullInorrect()
        {
            string str = "";

            try
            {
                Contract.StringFilled<ArgumentException>(str);
                Assert.False(true, $"{nameof(ArgumentException)} expected");
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(ArgumentNullException)}");
            }
        }
    }
}