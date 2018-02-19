using System;
using System.Security.Cryptography;
using System.Text;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox.MVVMCross.TestNavigation.Droid.NativeServices
{
    public class RSAEncryption: IRSAEncryption
    {
        const string publicKey = "<RSAParameters><Exponent>AQAB</Exponent><Modulus>5K6FkBoMXs0F+ZZxzgxAOJYx2rv8e8UWA9UIO2xiNmKWUXzmLie8GodQOtehaNM8edwHkPtj4XTwml0h3BgoJ8yzAGgZ6eVkEca9YDSBm/dVL0n+uJG0EjkZHUeb12hPHIXjXYmxarUcRwIxkpISAmd+Pfiryd+djwAzBtMWpRE=</Modulus></RSAParameters>";
        const string privateKey = "<RSAParameters><Exponent>AQAB</Exponent><Modulus>5K6FkBoMXs0F+ZZxzgxAOJYx2rv8e8UWA9UIO2xiNmKWUXzmLie8GodQOtehaNM8edwHkPtj4XTwml0h3BgoJ8yzAGgZ6eVkEca9YDSBm/dVL0n+uJG0EjkZHUeb12hPHIXjXYmxarUcRwIxkpISAmd+Pfiryd+djwAzBtMWpRE=</Modulus><P>/zw8rBRN5nG40NDueuZfEcOiVInyRwa6xQ1JU2C1SOSulS2WAMRkMUldmGEeZ7VdKVaPge+iGl/ibwIIqnh2Fw==</P><Q>5V3rG+sGq/sOXYaYIfvn/S+zHek7BEzF8g3LqBgdcAqoG1OXy3AA3ve2r060yyAPEvJKN+5ZEQGm6r6UTYrfFw==</Q><DP>LaHSYx2aM9ofJc5E5NotIxrr+dtT4pj0aWiPtIV0w9yGzgsBZ4+1Lg6k2ip66iXFyy87pwp12+tKq3gcnoW87w==</DP><DQ>aUVMxhh9jGuCsVw38MkMNcExxVWpV5Tg+PJp+XFv+V96vmgEcEOssqkguJ84DU5efMSlWbxUNqD6eh0UNe656w==</DQ><InverseQ>31ABEViXYxKU0rAOH2xMgtS99JKCob7PRhfYRxptX6W/cRAHdEpHJM+BOYy82gCTCgGtfjJ9Cdd4nQtU6iEuIQ==</InverseQ><D>AbxBTzf4uA9zktKix8mCretAiERnmhjYyJapRVTWj0sYO5i9tm6ews9xZcDqfKfTDFRbH60zXiv2V3WKzZIcBo2drVHUYdBgsrQ4Bvqw6YK0m2PuBH84ObfJfGP3hWWUoyUHZbgDvDM6u/EmYulkxaRLohhylLWmxEmLEg/o3vE=</D></RSAParameters>";

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

        public string Decrypt(string strText)
        {

            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = strText;

                    // server decrypting data with private key                    
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, false);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
