using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Toolkit.Contracts;

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
        /// <exception cref="ArgumentException"/>
        /// <exception cref="KeyNotFoundException"/>
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

                if (settings.ContainsKey(key))
                {
                    settings.Remove(key);
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

        /// <summary>
        /// Retrieving settings value by text key.
        /// <para>If setting is't available the method returns null</para>
        /// </summary>
        /// <param name="key">The key by which the setting value is stored</param>
        /// <returns><strong>Setting's object or null if no such setting is found.</strong></returns>
        public object TryGetSetting(string key)
        {
            if (!string.IsNullOrWhiteSpace(key) && settings.TryGetValue(key, out var setting))
            {
                return setting;
            }

            return null;
        }

        /// <summary>
        /// Delete setting by key
        /// </summary>
        /// <param name="key">The key by which the setting value is stored</param>
        public void RemoveSetting(string key)
        {
            if (!string.IsNullOrWhiteSpace(key))
            {
                settings.Remove(key);
            }
        }

        #region Serialization

        /// <summary>
        /// Deserialize settings from string
        /// </summary>
        /// <param name="value">JSON string. <strong>Can't be null</strong>.</param>
        /// <param name="status">Conflict resolution method.
        /// <para>1. <see cref="ReplacementStatus.Rewrite"/> - Delete all existing settings and add loaded</para>
        /// <para>2. <see cref="ReplacementStatus.Replace"/> - Add loaded settings replacing existing settings with loaded ones</para>
        /// <para>3. <see cref="ReplacementStatus.Rewrite"/> - Add loaded settings without overwriting existing ones</para>
        /// </param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <exception cref="FormatException"/>
        public void DeserializeFromJSON(in string value, in ReplacementStatus status)
        {
            Contract.StringNotNullOrWhiteSpace<ArgumentException>(value);

            if (JsonConvert.DeserializeObject<IDictionary<string, object>>(value) is IDictionary<string, object> loadedSettings)
            {
                switch (status)
                {
                    case ReplacementStatus.Rewrite:
                        RewriteSettings(loadedSettings);
                        break;
                    case ReplacementStatus.Replace:
                        ReplaceSettings(loadedSettings);
                        break;
                    case ReplacementStatus.Add:
                        AddSettings(loadedSettings);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"No expected behavior from {status}");
                }
            }
            else
            {
                throw new FormatException("Couldn't deserialize string");
            }
        }

        /// <summary>
        /// Deserialize settings from stream
        /// </summary>
        /// <param name="value">JSON string inside stream. <strong>Can't be null</strong>.</param>
        /// <param name="status">Conflict resolution method.
        /// <para>1. <see cref="ReplacementStatus.Rewrite"/> - Delete all existing settings and add loaded</para>
        /// <para>2. <see cref="ReplacementStatus.Replace"/> - Add loaded settings replacing existing settings with loaded ones</para>
        /// <para>3. <see cref="ReplacementStatus.Rewrite"/> - Add loaded settings without overwriting existing ones</para>
        /// </param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="AccessViolationException"/>
        public void DeserializeFromJSON(in Stream stream, in ReplacementStatus status)
        {
            Contract.NotNull<Stream, ArgumentException>(stream);
            Contract.Is<AccessViolationException>(stream.CanRead);

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }
            using (StreamReader sr = new StreamReader(stream))
            {
                DeserializeFromJSON(sr.ReadToEnd(), status);
            }
        }

        /// <summary>
        /// Delete current settings and load saved
        /// </summary>
        /// <param name="loadedSettings">Dictionary with loaded settings</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="NullReferenceException"/>
        private void RewriteSettings(in IDictionary<string, object> loadedSettings)
        {
            Contract.NotNull<IDictionary<string, object>, ArgumentNullException>(loadedSettings);

            settings.Clear();
            foreach (var setting in loadedSettings)
            {
                Contract.NotNull<string, NullReferenceException>(setting.Key);

                this[setting.Key] = setting.Value;
            }
        }

        /// <summary>
        /// Add loaded settings replacing existing settings with loaded ones
        /// </summary>
        /// <param name="loadedSettings">Dictionary with loaded settings</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="NullReferenceException"/>
        private void ReplaceSettings(in IDictionary<string, object> loadedSettings)
        {
            Contract.NotNull<IDictionary<string, object>, ArgumentNullException>(loadedSettings);

            foreach (var setting in loadedSettings)
            {
                Contract.NotNull<string, NullReferenceException>(setting.Key);

                this[setting.Key] = setting.Value;
            }
        }

        /// <summary>
        /// Add loaded settings without overwriting existing ones
        /// </summary>
        /// <param name="loadedSettings">Dictionary with loaded settings</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="NullReferenceException"/>
        private void AddSettings(in IDictionary<string, object> loadedSettings)
        {
            Contract.NotNull<IDictionary<string, object>, ArgumentNullException>(loadedSettings);

            foreach (var setting in loadedSettings)
            {
                Contract.NotNull<string, NullReferenceException>(setting.Key);

                if (!settings.ContainsKey(setting.Key))
                {
                    this[setting.Key] = setting.Value;
                }
            }
        }

        /// <summary>
        /// Convert settings to JSON
        /// </summary>
        /// <returns><strong>Serialized string containing settings</strong></returns>
        public string SerializeToJSON()
        {
            return JsonConvert.SerializeObject(settings);
        }

        /// <summary>
        /// Write serialized data to a stream
        /// </summary>
        /// <param name="stream">The stream at the end of which data will be written</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="AccessViolationException"/>
        public Stream SerializeToJSON(Stream stream)
        {
            Contract.NotNull<Stream, ArgumentNullException>(stream);
            Contract.Is<AccessViolationException>(stream.CanWrite);

            string JSONString = SerializeToJSON();
            if (Check.StringNotNullOrWhiteSpace(JSONString) && stream.CanWrite)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(JSONString);
                stream.Write(bytes, checked((int)stream.Length), bytes.Length);
            }

            return stream;
        }

        #endregion
    }
}