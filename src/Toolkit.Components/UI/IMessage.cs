using System;

namespace Toolkit.Components.UI
{
    /// <summary>
    /// Interface for encapsulating a dialog box with a user, without interference with the UI
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Calling a dialogue for displaying messages
        /// </summary>
        /// <param name="message">Message text</param>
        /// <param name="title">The headline of the message (optional)</param>
        void Write(string message, string title = null);
    }
}