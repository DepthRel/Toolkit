using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Toolkit.Components.ViewModels;
using Xunit;

namespace Toolkit.Tests.ViewModels
{
    public class RelayCommandTests
    {
        [Fact]
        public void InvokeCommandCorrect()
        {
            IList<string> list = new List<string>();

            ICommand command = new RelayCommand(arg =>
            {
                list.Add((string)arg);
            });

            command.Execute("string");

            Assert.Single(list);
            Assert.Equal("string", list.First());
        }

        [Fact]
        public void InvokeGenericCommandCorrect()
        {
            IList<string> list = new List<string>();

            ICommand command = new RelayCommand<string>(arg =>
            {
                list.Add(arg);
            });

            command.Execute("string");

            Assert.Single(list);
            Assert.Equal("string", list.First());
        }
    }
}