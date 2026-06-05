using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Services.Serialization
{
    internal class PlaintextStrategy : IEncryptionStrategy
    {
        public byte[] Encrypt(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public string Decrypt(byte[] encryptedBytes)
        {
            return Encoding.UTF8.GetString(encryptedBytes);
        }
    }
}
