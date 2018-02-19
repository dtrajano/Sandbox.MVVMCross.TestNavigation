using System;
using System.Security.Cryptography;
using System.Text;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox.MVVMCross.TestNavigation.Droid.NativeServices
{
    public class RSAEncryption: IRSAEncryption
    {
        const string publicKey = "<RSAParameters><Exponent>AQAB</Exponent><Modulus>5K6FkBoMXs0F+ZZxzgxAOJYx2rv8e8UWA9UIO2xiNmKWUXzmLie8GodQOtehaNM8edwHkPtj4XTwml0h3BgoJ8yzAGgZ6eVkEca9YDSBm/dVL0n+uJG0EjkZHUeb12hPHIXjXYmxarUcRwIxkpISAmd+Pfiryd+djwAzBtMWpRE=</Modulus></RSAParameters>";

        public string Encrypt(string strData)
        {
            var byteData = Encoding.UTF8.GetBytes(strData);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var rsaParameters = rsa.ExportParameters(false);

                    rsa.FromXmlString(publicKey);

                    var encryptedData = rsa.Encrypt(byteData, false);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
