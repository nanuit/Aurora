using Aurora.Crypt;

namespace AuroraUnitTests
{
    public class AuroraCrypt
    {
        [Test]
        public void TestEncrypt()
        {
            string originalString = "dummygummi20";
            string key = "myapp";
            string encoded = Encryption.Encrypt(originalString, key);
            Console.WriteLine($"Original:{originalString} key:{key} Encoded String:{encoded}");

            string decoded = Encryption.Decrypt(encoded, key);
            Console.WriteLine($"Encoded:{encoded} key:{key} Deccoded String:{decoded}");

        }
    }
}
