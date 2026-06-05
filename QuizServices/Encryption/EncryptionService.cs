using QuizServices.Serialization;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QuizServices.Encryption
{
    public class EncryptionService
    {
        private static EncryptionService? instance = null;
        // The key is filled with zeros. In a real application we should probably store an actual key in app secrets.
        private readonly byte[] aesKey = Enumerable.Repeat((byte)0, 32).ToArray();
        // The key is fake. In a real application we should probably store an actual key in app secrets.
        private readonly byte[] tripleDesKey = Enumerable.Range(1, 24).Select(num => (byte)num).ToArray();

        private EncryptionService() { }

        public static EncryptionService Instance {
            get {
                if (instance == null) {
                    instance = new EncryptionService();
                }
                return instance;
            }
        }

        public IEncryptionStrategy GetAesStrategy()
        {
            var aes = Aes.Create();
            aes.Key = aesKey;
            return new AesStrategy(aes);
        }

        public IEncryptionStrategy GetTripleDesStrategy()
        {
            var tripleDes = TripleDES.Create();
            tripleDes.Key = tripleDesKey;
            return new TripleDesStrategy(tripleDes);
        }
    }
}
