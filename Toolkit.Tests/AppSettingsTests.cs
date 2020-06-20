using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toolkit.Tests
{
    [TestClass]
    public class AppSettingsTests
    {
        [TestMethod]
        public void WriteAndReadSettingCorrect()
        {
            string name = "Dev";
            AppSettings.Setting["name"] = name;

            Assert.AreEqual(name, AppSettings.Setting["name"]);
        }

        [TestMethod]
        public void GetAllActualSettingsCorrect()
        {
            IEnumerable<string> settings = new List<string>() { "First", "Second", "Third" };

            foreach (var setting in settings)
            {
                AppSettings.Setting[setting] = setting;
            }

            var actualSettings = AppSettings.Setting.AvailableSettings;
            Assert.AreEqual(settings.Count(), actualSettings.Count());

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
                    Assert.Fail();
                }
            }
        }
    }
}