using System;
using System.Threading;
using Aurora.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLib
{
    [TestClass]
    public class AuroraMisc
    {
        [TestMethod]
        public void TestTheme()
        {
            Theme theme = new Theme();
            theme.WindowsThemeChanged += ThemeOnWindowsThemeChanged;
            Console.WriteLine($"Current WindowsTheme:{theme.WatchTheme()}");
            
            Thread.Sleep(-1);
        }

        private void ThemeOnWindowsThemeChanged(Theme.WindowsTheme newTheme)
        {
            Console.WriteLine("WindowsTheme Changed:{newTheme}");
        }
    }
}
