using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QuizGenerator.Services.Serialization
{
    internal class TripleDesStrategy : IEncryptionStrategy
    {
        private TripleDES tripleDes;

        public TripleDesStrategy(TripleDES tripleDes)
        {
            this.tripleDes = tripleDes;
        }

        public byte[] Encrypt(string text)
        {
            tripleDes.GenerateIV();

            var encryptor = tripleDes.CreateEncryptor();
            using (var msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(tripleDes.IV, 0, tripleDes.IV.Length);

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
            byte[] iv = new byte[tripleDes.BlockSize / 8];
            Array.Copy(encryptedBytes, 0, iv, 0, iv.Length);
            tripleDes.IV = iv;

            var decryptor = tripleDes.CreateDecryptor();
            using (var msDecrypt = new MemoryStream(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new StreamReader(csDecrypt))
                return srDecrypt.ReadToEnd();
        }
    }
}
