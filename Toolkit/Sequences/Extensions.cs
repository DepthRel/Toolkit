using System;
using System.Collections.Generic;
using System.Linq;

namespace Toolkit.Sequences
{
    /// <summary>
    /// Class for extension methods and analogues of these methods for sequences.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Getting a new sequence with elements in random order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> Reorder<T>(in IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(x => Guid.NewGuid());
        }

        /// <summary>
        /// Getting a new sequence with elements in random order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> Reorder<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(x => Guid.NewGuid());
        }

        /// <summary>
        /// Swap argument values with each other
        /// </summary>
        /// <typeparam name="T">Variable's type</typeparam>
        /// <param name="left">First swapped value</param>
        /// <param name="right">Second swapped value</param>
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}