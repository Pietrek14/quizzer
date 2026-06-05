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
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (var msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(aes.IV, 0, aes.IV.Length);

                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(text);
                }

                return msEncrypt.ToArray();
            }
        }

        public string Decrypt(byte[] encryptedBytes)
        {
            byte[] iv = new byte[aes.BlockSize / 8];
            Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);
            aes.IV = iv;

            var decryptor = aes.CreateDecryptor();
            using (var msDecrypt = new MemoryStream(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
                return srDecrypt.ReadToEnd();
        }
    }
}
