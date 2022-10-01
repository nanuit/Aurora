using Aurora.Crypt;

namespace AuroraUnitTests
{
    public class AuroraCrypt
    {
        [Test]
        public void TestDeEncrypt()
        {
            string originalString = "dummygummi20";
            string key = "myapp";
            string encoded = Encryption.Encrypt(originalString, key);
            Console.WriteLine($"Original:{originalString} key:{key} Encoded String:{encoded}");

            string decoded = Encryption.Decrypt(encoded, key);
            Console.WriteLine($"Encoded:{encoded} key:{key} Decoded String:{decoded}");
        }
        [Test]
        public void TestDecrypt()
        {
            string key= "B2C1323D-038B-4E8A-A142-BE8C20009A0D";
            string encoded = "h6vzidqjL10nc0HnLFhlYxhbvnFLmG5rK4FrGm4MLe78T+YVoqQDYCYnRbxhI5/RH5TODbNSquF++s/ku/UdHg==";
            string decoded = Encryption.Decrypt(encoded, key);
            Console.WriteLine($"Encoded:{encoded} key:{key} Deccoded String:{decoded}");
        }
    }
}
