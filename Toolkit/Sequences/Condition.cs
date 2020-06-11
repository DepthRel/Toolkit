using System;

namespace Toolkit.Sequences
{
    /// <summary>
    /// Creating a condition chain to use expressions such as AND and OR
    /// Has overloaded operators "&" and "|" for combine multiple Condition
    /// Каждый результат цепочки выражения неявно преобразуется в bool
    /// </summary>
    public class Condition
    {
        /// <summary>
        /// Mutable condition during the execution of the call chain
        /// </summary>
        private bool result;

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
        /// <returns></returns>
        public static Condition Check(in bool condition)
        {
            return new Condition(condition);
        }

        #region Conditions

        /// <summary>
        /// Analogue of the expression "&&"
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns>A current object that is ready for implicit conversion to bool</returns>
        public Condition And(in bool condition)
        {
            result = result && condition;
            return this;
        }

        /// <summary>
        /// Analogue of the expression "||"
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns>A current object that is ready for implicit conversion to bool</returns>
        public Condition Or(in bool condition)
        {
            result = result || condition;
            return this;
        }

        /// <summary>
        /// Condition "&&" for inverted parameter value
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns>A current object that is ready for implicit conversion to bool</returns>
        public Condition AndNot(in bool condition)
        {
            result = result && !condition;
            return this;
        }

        /// <summary>
        /// Condition "||" for inverted parameter value
        /// </summary>
        /// <param name="condition">Applicable condition</param>
        /// <returns>A current object that is ready for implicit conversion to bool</returns>
        public Condition OrNot(in bool condition)
        {
            result = result || !condition;
            return this;
        }

        /// <summary>
        /// Invert current condition. Analogue of the expression "!"
        /// </summary>
        /// <returns>A current object that is ready for implicit conversion to bool</returns>
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
        /// <param name="condition"></param>
        public static implicit operator bool(in Condition condition)
        {
            return condition.result;
        }

        public static Condition operator &(in Condition left, in Condition right)
        {
            return new Condition(left.result && right.result);
        }

        public static Condition operator |(in Condition left, in Condition right)
        {
            return new Condition(left.result || right.result);
        }

        #endregion
    }
}