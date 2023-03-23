using Aurora.IO;

namespace AuroraUnitTests
{
    internal class AuroraIO
    {
        [Test]
        public void TestEnsureDirectory()
        {
            try
            {
                Aurora.IO.Directory.EnsureDirectory(@"c:\var\gummigut");
                Aurora.IO.Directory.EnsureFileDirectory(@"c:\var\gummigut\filedir\file.txt");
                Aurora.IO.Directory.EnsureSubDirectory(@"c:\var\gummigut", "subdir");

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
