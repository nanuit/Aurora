using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aurora.Crypt;

namespace AuroraUnitTestLegacy
{
    [TestClass]
    public class AuroraCrypt
    {
        [TestMethod]
        public void TestRijndael()
        {
            string originalString = "dummygummi20";
            string key = "myapp";
            string encoded = RijndaelCrypt.Encrypt(originalString, key);
            Console.WriteLine($"Original:{originalString} key:{key} Encoded String:{encoded}");

            string decoded = RijndaelCrypt.Decrypt(encoded, key);
            Console.WriteLine($"Encoded:{encoded} key:{key} Deccoded String:{decoded}");

        }
    }
}
