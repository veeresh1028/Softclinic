using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer
{
    public class Encryptions
    {
        const int SALT_BYTE_SIZE = 32;
        const int HASH_BYTE_SIZE = 32;
        const int PBKDF2_ITERATIONS = 12341;

        public static bool ValidatePassword(string password, string dbHash, string dbSalt)
        {
            //int PBKDF2_ITERATIONS = 12341;
            byte[] salt = Convert.FromBase64String(dbSalt);
            byte[] hash = Convert.FromBase64String(dbHash);

            byte[] testHash = PBKDF2(password, salt, PBKDF2_ITERATIONS, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        public static string CreateHash(string password, out string saltpass)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);

            saltpass = Convert.ToBase64String(salt);
            return Convert.ToBase64String(hash);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public static byte[] GetHashKey(string hashKey)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            string salt = "VISION LICENSE";
            byte[] saltBytes = encoder.GetBytes(salt);
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            return rfc.GetBytes(16);
        }

        public static byte[] GetHashKeyForVision(string hashKey)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            string salt = "RUTWIK MANISH";
            byte[] saltBytes = encoder.GetBytes(salt);
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(hashKey, saltBytes);
            return rfc.GetBytes(16);
        }

        public static string Encrypt(byte[] key, string dataToEncrypt)
        {
            // Initialize
            AesManaged encryptor = new AesManaged();
            // Set the key
            encryptor.Key = key;
            encryptor.IV = key;
            // create a memory stream
            using (MemoryStream encryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream encrypt = new CryptoStream(encryptionStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    byte[] utfD1 = UTF8Encoding.UTF8.GetBytes(dataToEncrypt);
                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    // Return the encrypted data
                    return Convert.ToBase64String(encryptionStream.ToArray());
                }
            }
        }

        public static string Decrypt(byte[] key, string encryptedString)
        {
            // Initialize
            AesManaged decryptor = new AesManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptedString);
            // Set the key
            decryptor.Key = key;
            decryptor.IV = key;
            // create a memory stream
            using (MemoryStream decryptionStream = new MemoryStream())
            {
                // Create the crypto stream
                using (CryptoStream decrypt = new CryptoStream(decryptionStream, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    // Encrypt
                    decrypt.Write(encryptedData, 0, encryptedData.Length);
                    decrypt.Flush();
                    decrypt.Close();
                    // Return the unencrypted data
                    byte[] decryptedData = decryptionStream.ToArray();
                    return UTF8Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
                }
            }
        }
    }
}
