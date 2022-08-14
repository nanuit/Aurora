using System;
using System.Reflection;
using System.Threading;
using Aurora.Misc;
using Aurora.Misc.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLib
{
    [TestClass]
    public class AuroraMisc
    {
#if NET48
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
#endif
        [TestMethod]
        public void TestCustomBuildDate()
        {
            try { var date = Assembly.GetExecutingAssembly().GetCustomAssemblyLinkDateUtc();
                Console.WriteLine(date.ToString("u"));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
