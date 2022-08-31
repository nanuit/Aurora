using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Aurora.Misc.String;
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
        [TestMethod]
        public void TestStringExtension()
        {
            byte[] byteArray = { 36, 37, 10, 45, 66, 13, 45, 67 };
            Console.WriteLine ($"byte[]: {byteArray.StringFromByte()}");
            string byteString = Encoding.UTF8.GetString(byteArray);
            Console.WriteLine($"back to string{byteString}");
            Console.WriteLine($"To hex string{byteString.StringFromByte()}");
            byteString = @"\x3tReddref\x4";
            Console.WriteLine($"string: {byteString.StringFromByte()}");
        }
    }
}
