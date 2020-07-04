using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Toolkit.Components.ViewModels;

namespace Toolkit.Tests.ViewModels
{
    [TestClass]
    public class RelayCommandTests
    {
        [TestMethod]
        public void InvokeCommandCorrect()
        {
            IList<string> list = new List<string>();

            ICommand command = new RelayCommand(arg =>
            {
                list.Add((string)arg);
            });

            command.Execute("string");

            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list.First(), "string");
        }

        [TestMethod]
        public void InvokeGenericCommandCorrect()
        {
            IList<string> list = new List<string>();

            ICommand command = new RelayCommand<string>(arg =>
            {
                list.Add(arg);
            });

            command.Execute("string");

            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list.First(), "string");
        }
    }
}