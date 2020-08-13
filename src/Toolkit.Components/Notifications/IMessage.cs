using System;

namespace Toolkit.Components.Notifications
{
    /// <summary>
    /// Interface for encapsulating a dialog service with a user, without interference with the UI
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Calling a dialogue for displaying messages
        /// </summary>
        void Report();
    }
}