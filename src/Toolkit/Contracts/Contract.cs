using System;
using System.Collections.Generic;

namespace Toolkit.Contracts
{
    /// <summary>
    /// A class that allows succinctly checking logical values
    /// </summary>
    public static class Contract
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
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="arg">Checked object</param>
        /// <returns>Checked object</returns>
        public static T NotNull<T, TEx>(in T arg) where TEx : Exception, new()
        {
            if (arg == null) throw new TEx();

            return arg;
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="args">Array of objects</param>
        /// <returns>Array of checked objects</returns>
        public static IEnumerable<T> NotNull<T, TEx>(params T[] args) where TEx : Exception, new()
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null) throw new TEx();
            }

            return args;
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="args">Array of objects</param>
        /// <returns>Array of checked objects</returns>
        public static IEnumerable<object> NotNull<TEx>(params object[] args) where TEx : Exception, new()
        {
            if (!NotNull(args))
            {
                throw new TEx();
            }

            return args;
        }

        #endregion

        #region String Check

        /// <summary>
        /// The statement that the string is not empty and not null
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="arg">Checked string</param>
        /// <returns>Original checked string/returns>
        public static string StringNotNullOrWhiteSpace<TEx>(in string arg) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(arg?.Trim())) throw new TEx();

            return arg;
        }

        #endregion

        #region Equal Check

        /// <summary>
        /// The statement that the values are equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void Equal<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) != 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the values are not equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void NotEqual<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) == 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is greater than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void MoreOrEqualThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) < 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is greater than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void MoreThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) <= 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is not greater than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void NotMoreOrEqualThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) > 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is less than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void LessOrEqualThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) > 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is less than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void LessThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) >= 0)
            {
                throw new TEx();
            }
        }

        /// <summary>
        /// The statement that the value is not less than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        public static void NotLessOrEqualThan<T, TEx>(in T left, in T right)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) < 0)
            {
                throw new TEx();
            }
        }

        #endregion

        #region Universal Check

        /// <summary>
        /// Statement that the result of a boolean expression is true
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="condition">Logical expression</param>
        public static void Is<TEx>(in bool condition) where TEx : Exception, new()
        {
            if (!condition) throw new TEx();
        }

        /// <summary>
        /// Statement that the result of a boolean expression is false
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="condition">Logical expression</param>
        public static void IsNot<TEx>(in bool condition) where TEx : Exception, new()
        {
            if (condition) throw new TEx();
        }

        #endregion
    }
}