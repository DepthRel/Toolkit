using System;

namespace Toolkit.Components.UI
{
    interface IResolutionMessage<T>
    {
        /// <summary>
        /// Calling a dialogue for decision making
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="title">The headline of the message (optional)</param>
        /// <returns><strong>User decision result</strong></returns>
        T Write(string message, string title = null);
    }
}