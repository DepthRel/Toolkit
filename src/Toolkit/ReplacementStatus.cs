using System;

namespace Toolkit
{
    public enum ReplacementStatus
    {
        /// <summary>
        /// Clear current values and set loaded
        /// </summary>
        Rewrite,
        /// <summary>
        /// Add all and replace existing values with loaded ones
        /// </summary>
        Replace,
        /// <summary>
        /// Add nonexistent values
        /// </summary>
        Add
    }
}