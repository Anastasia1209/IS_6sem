using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab07
{
    public class Encryption
    {
        public static string WriteToFile(string fileName, string text)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab07\\";
            string filePath = Path.Combine(path, fileName);
            File.WriteAllText(filePath, text);
            return filePath;
        }
        public static string EncryptFile(string key, byte[] data)
        {
            byte[] encryptedBytes;

            using (MemoryStream msEncrypted = new MemoryStream())
            {
                using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                {
                    DES.Key = Encoding.ASCII.GetBytes(key);
                    DES.IV = Encoding.ASCII.GetBytes(key);

                    ICryptoTransform desencrypt = DES.CreateEncryptor();

                    using (CryptoStream cryptoStream = new CryptoStream(msEncrypted, desencrypt, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                }

                encryptedBytes = msEncrypted.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptFile(string key, byte[] data)
        {
            byte[] decryptedBytes;

            using (MemoryStream msInput = new MemoryStream(data))
            {
                using (MemoryStream msDecrypted = new MemoryStream())
                {
                    using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
                    {
                        DES.Key = Encoding.ASCII.GetBytes(key);
                        DES.IV = Encoding.ASCII.GetBytes(key);

                        ICryptoTransform desdecrypt = DES.CreateDecryptor();

                        using (CryptoStream cryptoStream = new CryptoStream(msInput, desdecrypt, CryptoStreamMode.Read))
                        {
                            cryptoStream.CopyTo(msDecrypted);
                        }
                    }

                    decryptedBytes = msDecrypted.ToArray();
                }
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
