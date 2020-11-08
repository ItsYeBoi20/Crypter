using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Crypter.Methods
{
    class Triple_DES
    {
		public static string Encrypt(string value, string password, string salt)
		{
			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));
			SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider();
			byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);
			ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);
			using (MemoryStream buffer = new MemoryStream())
			{
				using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
				{
					using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
					{
						writer.Write(value);
					}
				}
				return Convert.ToBase64String(buffer.ToArray());
			}
		}

		public static string Decrypt(string text, string password, string salt)
		{
			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));
			SymmetricAlgorithm algorithm = new TripleDESCryptoServiceProvider();
			byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);
			ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);
			using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
			{
				using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
				{
					using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
					{
						return reader.ReadToEnd();
					}
				}
			}
		}
	}
}
