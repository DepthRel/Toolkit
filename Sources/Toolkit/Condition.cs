using System;

namespace Toolkit
{
    /// <summary>
    /// <para>
    ///     Creating a condition chain to use expressions such as AND and OR.
    /// </para>
    /// <para>
    ///     Has overloaded operators "&" and "|" for combine multiple Condition.
    /// </para>
    /// <para>
    ///     Each result of an expression chain is implicitly converted to bool.
    /// </para>
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Mutable condition during the execution of the call chain
        /// </summary>
        protected bool result;

        /// <summary>
        /// Closed constructor to initialize the initial condition
        /// </summary>
        /// <param name="condition">Initial condition</param>
        private Condition(in bool condition)
        {
            result = condition;
        }

        /// <summary>
        /// Entry point to condition's builder
        /// </summary>
        /// <param name="condition">Initial condition</param>
        /// <returns><strong>Variable <see cref="Condition"/> which can be implicitly cast to bool type.</strong></returns>
        public static Condition Check(in bool condition)
        {
            return new Condition(condition);
        }

        #region Conditions

        /// <summary>
        /// Analogue of the expression "&&"
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns><strong>A current object that is ready for implicit conversion to bool</strong></returns>
        public Condition And(in bool condition)
        {
            result = result && condition;
            return this;
        }

        /// <summary>
        /// Analogue of the expression "||"
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns><strong>A current object that is ready for implicit conversion to bool</strong></returns>
        public Condition Or(in bool condition)
        {
            result = result || condition;
            return this;
        }

        /// <summary>
        /// Condition "&&" for inverted parameter value
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns><strong>A current object that is ready for implicit conversion to bool</strong></returns>
        public Condition AndNot(in bool condition)
        {
            result = result && !condition;
            return this;
        }

        /// <summary>
        /// Condition "||" for inverted parameter value
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns><strong>A current object that is ready for implicit conversion to bool</strong></returns>
        public Condition OrNot(in bool condition)
        {
            result = result || !condition;
            return this;
        }

        /// <summary>
        /// Invert current condition. Analogue of the expression "!"
        /// </summary>
        /// <returns><strong>A current object that is ready for implicit conversion to bool</strong></returns>
        public Condition Not()
        {
            result = !result;
            return this;
        }

        #endregion

        #region Type conversion operators

        /// <summary>
        /// Implicit conversion operator to bool
        /// </summary>
        /// <param name="condition"><strong>Current condition</strong></param>
        public static implicit operator bool(in Condition condition)
        {
            return condition.result;
        }

        /// <summary>
        /// Combining two conditions as AND (&&) 
        /// </summary>
        /// <param name="left">First condition</param>
        /// <param name="right">Second condition</param>
        /// <returns><strong>A new condition obtained by combining two conditions through AND</strong></returns>
        public static Condition operator &(in Condition left, in Condition right)
        {
            return new Condition(left.result && right.result);
        }

        /// <summary>
        /// Combining two conditions as OR (||) 
        /// </summary>
        /// <param name="left">First condition</param>
        /// <param name="right">Second condition</param>
        /// <returns><strong>A new condition obtained by combining two conditions through OR</strong></returns>
        public static Condition operator |(in Condition left, in Condition right)
        {
            return new Condition(left.result || right.result);
        }

        #endregion
    }
}