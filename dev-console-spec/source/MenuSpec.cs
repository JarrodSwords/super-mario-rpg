using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace DevConsole.Spec
{
    public class MenuSpec
    {
        #region Test Methods

        [Fact]
        public void WhenDisplaying_MainMenu()
        {
            var menu = new MainMenu();

            menu.GetOptions().Should().Contain(
                new KeyValuePair<byte, string>(1, "Character Management")
            );
        }

        #endregion
    }
}
