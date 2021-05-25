using System;
using Toolkit.Contracts;
using Xunit;

namespace Toolkit.Tests.Contracts
{
    public class EqualsContractTests
    {
        [Theory]
        [InlineData(5, 5)]
        public void EqualCorrect(int first, int second)
        {
            try
            {
                Contract.Equal<int, InvalidOperationException>(first, second);
                Assert.Equal(0, 0);
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void EqualIncorrect(int first, int second)
        {
            try
            {
                Contract.Equal<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotEqualCorrect(int first, int second)
        {
            try
            {
                Contract.NotEqual<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 5)]
        public void NotEqualIncorrect(int first, int second)
        {
            try
            {
                Contract.NotEqual<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 0)]
        public void MoreOrEqualThanCorrect(int first, int second)
        {
            try
            {
                Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void MoreOrEqualThanIncorrect(int first, int second)
        {
            try
            {
                Contract.MoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 0)]
        public void MoreThanCorrect(int first, int second)
        {
            try
            {
                Contract.MoreThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 5)]
        public void MoreThanIncorrect(int first, int second)
        {
            try
            {
                Contract.MoreThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotMoreOrEqualThanCorrect(int first, int second)
        {
            try
            {
                Contract.NotMoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 0)]
        public void NotMoreOrEqualThanIncorrect(int first, int second)
        {
            try
            {
                Contract.NotMoreOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(5, 10)]
        public void LessOrEqualThanCorrect(int first, int second)
        {
            try
            {
                Contract.LessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, -5)]
        public void LessOrEqualThanIncorrect(int first, int second)
        {
            try
            {
                Contract.LessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void LessThanCorrect(int first, int second)
        {
            try
            {
                Contract.LessThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 5)]
        public void LessThanIncorrect(int first, int second)
        {
            try
            {
                Contract.LessThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 0)]
        public void NotLessOrEqualThanCorrect(int first, int second)
        {
            try
            {
                Contract.NotLessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void NotLessOrEqualThanIncorrect(int first, int second)
        {
            try
            {
                Contract.NotLessOrEqualThan<int, InvalidOperationException>(first, second);
                Assert.False(true, $"{nameof(InvalidOperationException)} expected");
            }
            catch (InvalidOperationException)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void IsCorrect(int first, int second)
        {
            string str = "string";

            try
            {
                Contract.Is<InvalidOperationException>(first != second);
                Contract.Is<InvalidOperationException>(first < second);
                Contract.Is<InvalidOperationException>(first == 5);

                Contract.Is<InvalidOperationException>(str != null);
                Contract.Is<InvalidOperationException>(str == "string");

                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }

        [Theory]
        [InlineData(5, 10)]
        public void IsNotCorrect(int first, int second)
        {
            string str = "string";

            try
            {
                Contract.IsNot<InvalidOperationException>(first == second);
                Contract.IsNot<InvalidOperationException>(first > second);
                Contract.IsNot<InvalidOperationException>(first == 0);

                Contract.IsNot<InvalidOperationException>(str == null);
                Contract.IsNot<InvalidOperationException>(str != "string");

                Assert.True(true);
            }
            catch (InvalidOperationException)
            {
                Assert.False(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, $"An {ex.GetType()} has occurred. Expected {nameof(InvalidOperationException)}");
            }
        }
    }
}