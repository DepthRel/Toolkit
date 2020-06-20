using System;
using System.Collections.Generic;

namespace Toolkit
{
    public class AppSettings
    {
        #region Singleton implementation

        private static readonly Lazy<AppSettings> instance;
        public static AppSettings Setting => instance.Value;

        static AppSettings()
        {
            instance = new Lazy<AppSettings>(() => new AppSettings());
        }

        #endregion

        private readonly Dictionary<string, object> settings;

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

        public IEnumerable<string> AvailableSettings => settings.Keys;

        protected AppSettings()
        {
            settings = new Dictionary<string, object>();
        }
    }
}