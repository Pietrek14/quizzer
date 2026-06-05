using QuizModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace QuizServices.Serialization
{
    public class QuizSerializer
    {
        public IEncryptionStrategy EncryptionStrategy { get; set; }

        public QuizSerializer(IEncryptionStrategy strategy)
        {
            this.EncryptionStrategy = strategy;
        }

        public void Serialize(Quiz quiz, string filePath)
        {
            string json = JsonSerializer.Serialize(quiz);
            byte[] encrypted = this.EncryptionStrategy.Encrypt(json);

            File.WriteAllBytes(filePath, encrypted);
        }

        public Quiz Deserialize(string filePath)
        {
            byte[] encryptedBytes = File.ReadAllBytes(filePath);
            string decrypted = this.EncryptionStrategy.Decrypt(encryptedBytes);
            Quiz? quiz = JsonSerializer.Deserialize<Quiz>(decrypted);
            if(quiz == null)
            {
                throw new SerializationException("Failed to deserialize quiz");
            }
            return quiz;
        }
    }
}
