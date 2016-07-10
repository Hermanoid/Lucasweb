using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucasweb.Contracts;
using System.Security.Cryptography;
using System.IO;

namespace Lucasweb.Engines
{
    class EncryptEngine : IEncryptEngine
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public string GenericEncrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public string GenericDecrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        public string PinEncrypt(string Message, int Pin)
        {

            //I believe this list is 65000+ characters....   Not at all a drag on server resources.  Nope.
            List<char> chars = Enumerable.Range(0, char.MaxValue + 1)
                      .Select(i => (char)i)
                      .Where(c => !char.IsControl(c))
                      .ToList();

            //MessageChars, simplified.
            List<char> MCs = Message.ToList();
            //ha ha punny.
            List<char> Pincrypted = new List<char>();
            int charPos;
            int newPos;
            bool noProb;
            foreach (char MC in MCs)
            {
                charPos = chars.IndexOf(MC);
                newPos = charPos + Pin;
                noProb = false;
                while (!noProb)
                {
                    if (newPos >= chars.Count)
                    {
                        newPos -= chars.Count - 1;
                    }
                    else
                    {
                        noProb = true;
                    }
                }
                Pincrypted.Add(chars[newPos]);
            }
            return string.Join("", Pincrypted);

        }

        public string PinDecrypt(string Message, int Pin)
        {
            List<char> chars = Enumerable.Range(0, char.MaxValue + 1)
                      .Select(i => (char)i)
                      .Where(c => !char.IsControl(c))
                      .ToList();

            //MessageChars, simplified.
            List<char> MCs = Message.ToList();

            List<char> decrypted = new List<char>();
            int charPos;
            int newPos;
            bool noProb;
            foreach (char MC in MCs)
            {
                charPos = chars.IndexOf(MC);
                newPos = charPos - Pin;
                noProb = false;
                while (!noProb)
                {
                    if (newPos <= 0)
                    {
                        newPos += chars.Count - 1;
                    }
                    else
                    {
                        noProb = true;
                    }
                }
                decrypted.Add(chars[newPos]);
            }
            return string.Join("", decrypted);
        }

        public string CreatePassword()
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32];
                rng.GetBytes(tokenData);

                string token = Convert.ToBase64String(tokenData);
                return token;
            }
        }
    }
}
