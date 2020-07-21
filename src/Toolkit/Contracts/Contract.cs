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
        /// <returns><strong>Checked object</strong></returns>
        public static T NotNull<T, TEx>(in T arg) where TEx : Exception, new()
        {
            if (arg == null)
            {
                throw BuildException<TEx>();
            }

            return arg;
        }

        /// <summary>
        /// The statement that the parameter is not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="arg">Checked object</param>
        /// <param name="message">Information for exception</param>
        /// <returns><strong>Checked object</strong></returns>
        public static T NotNull<T, TEx>(in T arg, in string message) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return NotNull<T, TEx>(arg);
            }

            if (arg == null)
            {
                throw BuildException<TEx>(message);
            }

            return arg;
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="args">Array of objects</param>
        /// <returns><strong>Array of checked objects</strong></returns>
        public static IEnumerable<T> NotNull<T, TEx>(params T[] args) where TEx : Exception, new()
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    throw BuildException<TEx>();
                }
            }

            return args;
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="message">Information for exception</param>
        /// <param name="args">Array of objects</param>
        /// <returns><strong>Array of checked objects</strong></returns>
        public static IEnumerable<T> NotNull<T, TEx>(in string message, params T[] args) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return NotNull<T, TEx>(args);
            }

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    throw BuildException<TEx>(message);
                }
            }

            return args;
        }

        /// <summary>
        /// The statement that the parameters are not null
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="args">Array of objects</param>
        /// <returns><strong>Array of checked objects</strong></returns>
        public static IEnumerable<object> NotNull<TEx>(params object[] args) where TEx : Exception, new()
        {
            if (!NotNull(args))
            {
                throw BuildException<TEx>();
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
        /// <returns><strong>Original checked string</strong></returns>
        public static string StringNotNullOrWhiteSpace<TEx>(in string arg) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(arg?.Trim()))
            {
                throw BuildException<TEx>();
            }

            return arg;
        }

        /// <summary>
        /// The statement that the string is not empty and not null
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="arg">Checked string</param>
        /// <param name="message">Information for exception</param>
        /// <returns><strong>Original checked string</strong></returns>
        public static string StringNotNullOrWhiteSpace<TEx>(in string arg, in string message) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return StringNotNullOrWhiteSpace<TEx>(arg);
            }

            if (string.IsNullOrWhiteSpace(arg?.Trim()))
            {
                throw BuildException<TEx>(message);
            }

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
        /// <param name="message">Information for exception</param>
        public static void Equal<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) != 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the values are not equal
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void NotEqual<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) == 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is greater than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void MoreOrEqualThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) < 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is greater than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void MoreThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) <= 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is not greater than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void NotMoreOrEqualThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) > 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is less than or equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void LessOrEqualThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) > 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is less than the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void LessThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) >= 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// The statement that the value is not less than and not equal to the compared value
        /// </summary>
        /// <typeparam name="T">Type descendant of class Object</typeparam>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="left">Checked Value</param>
        /// <param name="right">Comparison value</param>
        /// <param name="message">Information for exception</param>
        public static void NotLessOrEqualThan<T, TEx>(in T left, in T right, in string message = null)
            where T : IComparable, IComparable<T>
            where TEx : Exception, new()
        {
            if (left.CompareTo(right) < 0)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw BuildException<TEx>();
                }

                throw BuildException<TEx>(message);
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
        /// Statement that the result of a boolean expression is true
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="condition">Logical expression</param>
        /// <param name="message">Information for exception</param>
        public static void Is<TEx>(in bool condition, in string message) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Is<TEx>(condition);
            }

            if (!condition)
            {
                throw BuildException<TEx>(message);
            }
        }

        /// <summary>
        /// Statement that the result of a boolean expression is false
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="condition">Logical expression</param>
        public static void IsNot<TEx>(in bool condition) where TEx : Exception, new()
        {
            if (condition)
            {
                throw BuildException<TEx>();
            }
        }

        /// <summary>
        /// Statement that the result of a boolean expression is false
        /// </summary>
        /// <typeparam name="TEx">Type of exception if the statement is incorrect. Inheritor of Exception class</typeparam>
        /// <param name="condition">Logical expression</param>
        /// <param name="message">Information for exception</param>
        public static void IsNot<TEx>(in bool condition, string message) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                IsNot<TEx>(condition);
            }

            if (condition)
            {
                throw BuildException<TEx>(message);
            }
        }

        #endregion

        /// <summary>
        /// Construct an exception with parameters
        /// </summary>
        /// <typeparam name="TEx">Exception type to be thrown</typeparam>
        /// <param name="message">Variable message to write to exception. If no message is specified, the standard constructor of the exception will be called.</param>
        /// <returns><strong>Constructed exception instance</strong></returns>
        private static Exception BuildException<TEx>(in string message = null) where TEx : Exception, new()
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return new TEx();
            }

            try
            {
                Exception exception = (Exception)Activator.CreateInstance(typeof(TEx), message);

                return exception;
            }
            catch (Exception)
            {
                return new TEx();
            }
        }
    }
}