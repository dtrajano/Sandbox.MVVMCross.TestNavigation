using System;
using System.Security.Cryptography;
using System.Text;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox_MVVMCross_TestNavigation.iOS.NativeServices
{
    public class RSAEncryption :IRSAEncryption
    {
        const string publicKey = "<RSAParameters><Exponent>AQAB</Exponent><Modulus></Modulus></RSAParameters>";
        const string privateKey = "<RSAParameters><Exponent>AQAB</Exponent><Modulus></Modulus><P></P><Q></Q><DP></DP><DQ></DQ><InverseQ></InverseQ><D></D></RSAParameters>";

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
