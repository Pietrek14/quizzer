using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace QuizGenerator.Services.Serialization
{
    public class AesStrategy : IEncryptionStrategy
    {
        private Aes aes;

        public AesStrategy(Aes aes)
        {
            this.aes = aes;
        }

        public byte[] Encrypt(string text)
        {
            var encryptor = aes.CreateEncryptor();
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                }

                return msEncrypt.ToArray();
            }
        }

        public string Decrypt(byte[] encryptedBytes)
        {
            var decryptor = aes.CreateDecryptor();
            using (var msDecrypt = new MemoryStream(encryptedBytes))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
