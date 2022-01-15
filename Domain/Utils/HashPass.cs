using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Utils
{
public class MD5Hash
    {
                public static string PlainText;
        public static string PassPhrase = "";
        public static string SaltValue = "s@1tValue";
        public static string HashAlgorithm = "MD5";
        public static int PasswordIterations = 2;
        public static string InitVector = "@1B2c3D4e5F6g7H8";
        public static int KeySize = 256;

        static MD5Hash()
        {
            PassPhrase = "93696feda1f70ceb3d69b8c411f077d5";
        }

        /// <summary>
        /// Realiza o Hash da senha utilizando a biblioteca MD5
        /// </summary>
        /// <param name="senha">Senha</param>
        /// <returns></returns>
        public static string Hash(string senha)
        {
            StringBuilder sBuilder;

            MD5 md5Hasher = null;

            try
            {
                md5Hasher = MD5.Create();
                var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(senha));

                sBuilder = new StringBuilder();
                foreach (byte c in data)
                    sBuilder.Append(c.ToString("x2"));
            }
            finally
            {
                if (md5Hasher != null)
                    md5Hasher.Dispose();
            }

            return sBuilder.ToString();
        }

        public static string Encrypt(string plainText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(PassPhrase, saltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            char fistCharacter = cipherText[0];
            char lastCharacter = cipherText[cipherText.Length - 1];
            string fullText = lastCharacter + cipherText + fistCharacter;
            fullText = fullText.Replace('+', '-');
            fullText = fullText.Replace('/', '_');
            return fullText;
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Remove(0, 1);
            cipherText = cipherText.Remove(cipherText.Length - 1, 1);
            cipherText = cipherText.Replace('-', '+');
            cipherText = cipherText.Replace('_', '/');
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(PassPhrase, saltValueBytes, HashAlgorithm, PasswordIterations);
#pragma warning disable 618
            byte[] keyBytes = password.GetBytes(KeySize / 8);
#pragma warning restore 618
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;
        }
    }
}