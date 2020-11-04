using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BlockBase.Cli.Helpers
{
    public class KeyStorage
    {
        private static readonly string KEYS_FOLDER = "keys/";

        public KeyStorage()
        {
        }

        public byte[] LoadKey(string keyName, string password)
        {
            var fileLine = FileWriterReader.ReadLine(KEYS_FOLDER + keyName);
            var encryptedData = System.Convert.FromBase64String(fileLine);
            var passwordBytes = System.Convert.FromBase64String(password);
            var decryptedKey = AES256.DecryptWithCBC(encryptedData, passwordBytes, new byte[16]);
            return decryptedKey;
        }

        public string SaveKey(string keyName, byte[] key)
        {
            var randomPassword = new byte[32];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(randomPassword);
            }
            var password = System.Convert.ToBase64String(randomPassword);
            var encryptedData = AES256.EncryptWithCBC(key, randomPassword, new byte[16]);
            var encryptedDataString = System.Convert.ToBase64String(encryptedData);
            FileWriterReader.Write(KEYS_FOLDER + keyName, encryptedDataString, System.IO.FileMode.Create);

            return password;
        }
    }
}