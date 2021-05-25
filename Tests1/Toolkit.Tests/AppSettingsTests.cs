using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Xunit;

namespace Toolkit.Tests
{
    public class AppSettingsTests
    {
        [Fact]
        public void WriteAndReadSettingCorrect()
        {
            string name = "Dev";
            AppSettings.Setting["name"] = name;

            Assert.Equal(name, AppSettings.Setting["name"]);
            ClearAllSettings();
        }

        [Fact]
        public void DoubleWriteSettingCorrect()
        {
            string name = "Dev";
            string temp = "Temp";
            AppSettings.Setting["name"] = temp;
            AppSettings.Setting["name"] = name;

            Assert.Equal(name, AppSettings.Setting["name"]);
            ClearAllSettings();
        }

        [Fact]
        public void RemoveSettingCorrect()
        {
            string name = "Dev";
            AppSettings.Setting["name"] = name;

            AppSettings.Setting.RemoveSetting(name);

            Assert.Null(AppSettings.Setting.TryGetSetting(name));
            ClearAllSettings();
        }

        [Fact]
        public void TryGetSettingCorrect()
        {
            string name = "Dev";
            AppSettings.Setting["name"] = name;

            Assert.Equal(name, AppSettings.Setting.TryGetSetting("name"));
            ClearAllSettings();

            double value = 3.14;
            AppSettings.Setting["name"] = value;

            Assert.Equal(value, AppSettings.Setting.TryGetSetting<double>("name"));
            ClearAllSettings();
        }

        [Fact]
        public void TryGetSettingIncorrect()
        {
            Assert.Null(AppSettings.Setting.TryGetSetting("name"));
            ClearAllSettings();
        }

        [Fact]
        public void GetAllActualSettingsCorrect()
        {
            IEnumerable<string> settings = new List<string>() { "First", "Second", "Third" };

            foreach (var setting in settings)
            {
                AppSettings.Setting[setting] = setting;
            }

            var actualSettings = AppSettings.Setting.AvailableSettings;
            Assert.Equal(settings.Count(), actualSettings.Count());

            foreach (var actualSetting in actualSettings)
            {
                bool isFind = false;

                foreach (var setting in settings)
                {
                    if (setting == actualSetting)
                    {
                        isFind = true;
                    }
                }

                if (!isFind)
                {
                    Assert.False(true);
                }
            }

            ClearAllSettings();
        }

        [Fact]
        public void SerializeSettingsToJSONCorrect()
        {
            string StringKey = "string";
            int IntKet = 1;
            double DoubleKey = 3.14;

            AppSettings.Setting[nameof(StringKey)] = StringKey;
            AppSettings.Setting[nameof(IntKet)] = IntKet;
            AppSettings.Setting[nameof(DoubleKey)] = DoubleKey;

            string settingsInJSON = AppSettings.Setting.SerializeToJSON();
            ClearAllSettings();

            AppSettings.Setting.DeserializeFromJSON(settingsInJSON, ReplacementStatus.Rewrite);

            Assert.Equal(StringKey, AppSettings.Setting[nameof(StringKey)]);
            Assert.Equal(IntKet, int.Parse(AppSettings.Setting[nameof(IntKet)].ToString()));
            Assert.Equal(DoubleKey, double.Parse(AppSettings.Setting[nameof(DoubleKey)].ToString()));

            ClearAllSettings();
        }

        [Fact]
        public void SerializeSettingsToJSONToStreamCorrect()
        {
            string StringKey = "string";
            int IntKet = 1;
            double DoubleKey = 3.14;

            AppSettings.Setting[nameof(StringKey)] = StringKey;
            AppSettings.Setting[nameof(IntKet)] = IntKet;
            AppSettings.Setting[nameof(DoubleKey)] = DoubleKey;

            Stream settingsInJSON = AppSettings.Setting.SerializeToJSON(new MemoryStream());
            ClearAllSettings();

            AppSettings.Setting.DeserializeFromJSON(settingsInJSON, ReplacementStatus.Rewrite);

            Assert.Equal(StringKey, AppSettings.Setting[nameof(StringKey)]);
            Assert.Equal(IntKet, int.Parse(AppSettings.Setting[nameof(IntKet)].ToString()));
            Assert.Equal(DoubleKey, double.Parse(AppSettings.Setting[nameof(DoubleKey)].ToString()));

            ClearAllSettings();
        }

        [Fact]
        public void SerializeSettingsToXMLCorrect()
        {
            string StringKey = "string";
            int IntKet = 1;
            double DoubleKey = 3.14;

            AppSettings.Setting[nameof(StringKey)] = StringKey;
            AppSettings.Setting[nameof(IntKet)] = IntKet;
            AppSettings.Setting[nameof(DoubleKey)] = DoubleKey;

            string settingsInXML = AppSettings.Setting.SerializeToXML();
            ClearAllSettings();

            AppSettings.Setting.DeserializeFromXML(settingsInXML, ReplacementStatus.Rewrite);

            Assert.Equal(StringKey, AppSettings.Setting[nameof(StringKey)]);
            Assert.Equal(IntKet, int.Parse(AppSettings.Setting[nameof(IntKet)].ToString()));
            Assert.Equal(DoubleKey, double.Parse(AppSettings.Setting[nameof(DoubleKey)].ToString(), CultureInfo.InvariantCulture));

            ClearAllSettings();
        }

        [Fact]
        public void SerializeSettingsToXMLToStreamCorrect()
        {
            string StringKey = "string";
            int IntKet = 1;
            double DoubleKey = 3.14;

            AppSettings.Setting[nameof(StringKey)] = StringKey;
            AppSettings.Setting[nameof(IntKet)] = IntKet;
            AppSettings.Setting[nameof(DoubleKey)] = DoubleKey;

            Stream settingsInXML = AppSettings.Setting.SerializeToXML(new MemoryStream());
            ClearAllSettings();

            AppSettings.Setting.DeserializeFromXML(settingsInXML, ReplacementStatus.Rewrite);

            Assert.Equal(StringKey, AppSettings.Setting[nameof(StringKey)]);
            Assert.Equal(IntKet, int.Parse(AppSettings.Setting[nameof(IntKet)].ToString()));
            Assert.Equal(DoubleKey, double.Parse(AppSettings.Setting[nameof(DoubleKey)].ToString(), CultureInfo.InvariantCulture));

            ClearAllSettings();
        }

        private void ClearAllSettings()
        {
            var actualSettings = AppSettings.Setting.AvailableSettings;

            foreach (var key in actualSettings)
            {
                AppSettings.Setting.RemoveSetting(key);
            }
        }
    }
}