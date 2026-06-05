using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizServices.Serialization
{
    public interface IEncryptionStrategy
    {
        byte[] Encrypt(string text);
        string Decrypt(byte[] encryptedBytes);
    }
}
