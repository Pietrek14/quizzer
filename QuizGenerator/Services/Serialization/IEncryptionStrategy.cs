using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizGenerator.Services.Serialization
{
    public interface IEncryptionStrategy
    {
        byte[] Encrypt(string text);
        string Decrypt(byte[] encryptedBytes);
    }
}
