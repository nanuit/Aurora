using System;
using System.Reflection;
using System.Threading;
using Aurora.Misc;
using Aurora.Misc.Application;


namespace AuroraTests
{    
    public class AuroraMisc
    {
#if NET48
        [Test]
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
        [Test]
        public void TestCustomBuildDate()
        {
            try {
                Console.WriteLine($"Utc: {Assembly.GetExecutingAssembly().GetCustomAssemblyLinkDateUtc():yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Local: {Assembly.GetExecutingAssembly().GetCustomAssemblyLinkDateLocal():yyyy-MM-dd HH:mm:ss}");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
