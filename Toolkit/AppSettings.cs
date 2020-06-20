﻿using System;
using System.Collections.Generic;

namespace Toolkit
{
    /// <summary>
    /// Singleton for storing application settings
    /// </summary>
    /// <example>
    /// <code>
    /// <see cref="AppSettings"/>.Setting["processId"] = Process.GetCurrentProcess().Id;
    /// int processId = <see cref="AppSettings"/>.Setting["processId"];
    /// </code>
    /// </example>
    public class AppSettings
    {
        #region Singleton implementation

        private static readonly Lazy<AppSettings> instance;

        /// <summary>
        /// An indexable property for writing and retrieving settings.
        /// </summary>
        /// <example>
        /// <code>
        /// Settings["id"] = currentId;
        /// </code>
        /// </example>
        public static AppSettings Setting => instance.Value;

        static AppSettings()
        {
            instance = new Lazy<AppSettings>(() => new AppSettings());
        }

        #endregion

        private readonly Dictionary<string, object> settings;

        /// <summary>
        /// Writing and retrieving settings value by text key
        /// </summary>
        /// <param name="key">Any unique non-empty string identifying the setting</param>
        /// <returns><strong><strong>Setting in <see cref="object"/> type</strong></strong></returns>
        public object this[string key]
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(key) && settings.TryGetValue(key, out var setting))
                {
                    return setting;
                }

                throw new KeyNotFoundException($"Can't to find setting with name \"{key}\"");
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentException($"The setting name is in the wrong format");
                }

                settings.Add(key, value);
            }
        }

        /// <summary>
        /// Property for obtaining the sequence of all available settings keys.
        /// </summary>
        public IEnumerable<string> AvailableSettings => settings.Keys;

        protected AppSettings()
        {
            settings = new Dictionary<string, object>();
        }
    }
}