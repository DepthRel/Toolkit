using System;
using Toolkit.Sequences;

namespace Toolkit.Contracts
{
    /// <summary>
    /// Verification of conditions. Unlike <see cref="Contract"/>, it does not cause an exception
    /// </summary>
    public class Check
    {
        #region Nullable Check

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <param name="args">Array of objects</param>
        /// <returns><strong>True if all objects not null</strong></returns>
        public static bool NotNull(params object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) return false;
            }

            return true;
        }

        /// <summary>
        /// The statement that the parameter is not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="arg">Checked object</param>
        public static bool NotNull<T>(in T arg)
        {
            return !(arg == null);
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="args">Array of objects</param>
        public static bool NotNull<T>(params T[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) return false;
            }

            return true;
        }

        #endregion

        #region String Check

        /// <summary>
        /// The statement that the string is not empty and not null
        /// </summary>
        /// <param name="arg">Checked string</param>
        public static bool StringFilled(in string arg) => arg?.Filled() ?? false;

        #endregion

        #region Equal Check

        /// <summary>
        /// The statement that the values are equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool Equal<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) != 0);
        }

        /// <summary>
        /// The statement that the values are not equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotEqual<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) == 0);
        }

        /// <summary>
        /// The statement that the value is greater than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool MoreOrEqualThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) < 0);
        }

        /// <summary>
        /// The statement that the value is greater than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool MoreThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) <= 0);
        }

        /// <summary>
        /// The statement that the value is not greater than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotMoreOrEqualThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) > 0);
        }

        /// <summary>
        /// The statement that the value is less than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool LessOrEqualThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) > 0);
        }

        /// <summary>
        /// The statement that the value is less than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool LessThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) >= 0);
        }

        /// <summary>
        /// The statement that the value is not less than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotLessOrEqualThan<T>(in T left, in T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) < 0);
        }

        #endregion
    }
}