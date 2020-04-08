using System;

namespace Toolkit.Contracts
{
    public class Check
    {
        #region Nullable Check

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <param name="args">Array of objects</param>
        /// <returns>True if all objects not null</returns>
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
        public static bool NotNull<T>(T arg)
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
        public static bool StringNotNullOrWhiteSpace(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg?.Trim());
        }

        #endregion

        #region Equal Check

        /// <summary>
        /// The statement that the values are equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool Equal<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) != 0);
        }

        /// <summary>
        /// The statement that the values are not equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotEqual<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) == 0);
        }

        /// <summary>
        /// The statement that the value is greater than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool MoreOrEqualThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) < 0);
        }

        /// <summary>
        /// The statement that the value is greater than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool MoreThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) <= 0);
        }

        /// <summary>
        /// The statement that the value is not greater than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotMoreOrEqualThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) > 0);
        }

        /// <summary>
        /// The statement that the value is less than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool LessOrEqualThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) > 0);
        }

        /// <summary>
        /// The statement that the value is less than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool LessThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) >= 0);
        }

        /// <summary>
        /// The statement that the value is not less than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static bool NotLessOrEqualThan<T>(T left, T right) where T : IComparable, IComparable<T>
        {
            return !(left.CompareTo(right) < 0);
        }

        #endregion
    }
}