using System;

namespace Toolkit.Components.UI
{
    /// <summary>
    /// Interface for requesting a solution
    /// </summary>
    /// <typeparam name="T">Query result type</typeparam>
    public interface IRequest<T>
    {
        /// <summary>
        /// Calling a dialogue for decision making
        /// </summary>
        /// <returns><strong>Decision result</strong></returns>
        T Request();
    }
}