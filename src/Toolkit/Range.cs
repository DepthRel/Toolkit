using System;
using Toolkit.Contracts;

namespace Toolkit
{
    /// <summary>
    /// A generic class for representing an range of two values. Provides methods for checking a value against a range.
    /// </summary>
    /// <typeparam name="T">Type descendant of class Object implementing interface IComparable and IComparable <></typeparam>
    public class Range<T> where T : IComparable, IComparable<T>, IEquatable<T>
    {
        protected readonly T left;
        protected readonly T right;

        /// <summary>
        /// The first value in the range. Necessarily less than the second value.
        /// </summary>
        public T Left => left;
        /// <summary>
        /// The value at the end of the range. Necessarily greater than the first value.
        /// </summary>
        public T Right => right;

        /// <summary>
        /// <para>
        ///     Initializing an interval with two values. The constructor checks which of the values is greater.</para>
        /// <para>
        ///     If the order is not correct, the arguments are rearranged.
        /// </para>
        /// </summary>
        /// <param name="first">The first value  in the range. Necessarily less than the second value.</param>
        /// <param name="second">The value at the end of the range. Necessarily greater than the first value.</param>
        /// <exception cref="ArgumentNullException">Thrown when one of parameters is null</exception>
        public Range(in T first, in T second)
        {
            Contract.NotNull<T, ArgumentNullException>(first);
            Contract.NotNull<T, ArgumentNullException>(second);

            if (first.CompareTo(second) < 0)
            {
                left = first;
                right = second;
            }
            else
            {
                right = first;
                left = second;
            }
        }

        /// <summary>
        /// Checks if the value lies inside and on the border of the range
        /// </summary>
        /// <param name="value">Value to range ratio</param>
        /// <returns><strong>The statement that the value lies within the range</strong></returns>
        /// <exception cref="ArgumentNullException">Thrown when value is null</exception>
        public bool Inside(in T value)
        {
            Contract.NotNull<T, ArgumentNullException>(value);

            return left.CompareTo(value) <= 0 && right.CompareTo(value) >= 0;
        }

        /// <summary>
        /// Checks if a value is out of range
        /// </summary>
        /// <param name="value">Value to range ratio</param>
        /// <returns><strong>The statement that the value is not within the range</strong></returns>
        /// <exception cref="ArgumentNullException">Thrown when value is null</exception>
        public bool Outside(in T value)
        {
            Contract.NotNull<T, ArgumentNullException>(value);

            return left.CompareTo(value) > 0 || right.CompareTo(value) < 0;
        }

        /// <summary>
        /// Checks if the value is within the range excluding the border
        /// </summary>
        /// <param name="value">Value to range ratio</param>
        /// <returns><strong>The statement that the value lies within the range not including the boundary</strong></returns>
        /// <exception cref="ArgumentNullException">Thrown when value is null</exception>
        public bool Between(in T value)
        {
            Contract.NotNull<T, ArgumentNullException>(value);

            return left.CompareTo(value) < 0 && right.CompareTo(value) > 0;
        }

        /// <summary>
        /// Checks if the value is after the interval
        /// </summary>
        /// <param name="value">Value to range ratio</param>
        /// <returns><strong>The statement that the value is after the range</strong></returns>
        /// <exception cref="ArgumentNullException">Thrown when value is null</exception>
        public bool Beyond(in T value)
        {
            Contract.NotNull<T, ArgumentNullException>(value);

            return right.CompareTo(value) < 0;
        }

        /// <summary>
        /// Checks if the value is before the interval
        /// </summary>
        /// <param name="value">Value to range ratio</param>
        /// <returns><strong>The statement that the value is before the range</strong></returns>
        /// <exception cref="ArgumentNullException">Thrown when value is null</exception>
        public bool Before(in T value)
        {
            Contract.NotNull<T, ArgumentNullException>(value);

            return left.CompareTo(value) > 0;
        }

        #region Overrides

        /// <summary>
        /// Verifies the values of the transmitted interval
        /// </summary>
        /// <param name="obj">Interval of <see cref="Range{T}"/> type</param>
        /// <returns><strong>True if each value of the transmitted interval matches the current</strong></returns>
        public override bool Equals(object obj)
        {
            if (obj is Range<T> value)
            {
                if (Left.CompareTo(value.Left) == 0 && Right.CompareTo(value.Right) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Getting a unique hash code
        /// </summary>
        /// <returns><strong>Unique hash code</strong></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Left.GetHashCode();
                result = (result * 397) ^ Right.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Getting a string in the format: <example><code>{Left}..{Right}</code></example>
        /// </summary>
        /// <returns><strong>String like: 1..9</strong></returns>
        public override string ToString()
        {
            return $"{Left}..{Right}";
        }

        #endregion

        #region Type conversion operators

        /// <summary>
        /// Check for equality of two intervals
        /// </summary>
        /// <param name="left">First interval</param>
        /// <param name="right">Second interval</param>
        /// <returns><strong>True if each interval value is equal to each other</strong></returns>
        public static bool operator ==(Range<T> left, Range<T> right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Left.CompareTo(right.Left) == 0 && left.Right.CompareTo(right.Right) == 0;
        }

        /// <summary>
        /// Check for inequality of two intervals
        /// </summary>
        /// <param name="left">First interval</param>
        /// <param name="right">Second interval</param>
        /// <returns><strong>True if each interval value is not equal to each other</strong></returns>
        public static bool operator !=(Range<T> left, Range<T> right)
        {
            if (left is null && right is null)
            {
                return false;
            }

            if (left is null || right is null)
            {
                return true;
            }

            if (left is null || right is null)
            {
                return true;
            }

            return left.Left.CompareTo(right.Left) != 0 || left.Right.CompareTo(right.Right) != 0;
        }

        #endregion
    }
}