using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
		public class Encryption
		{
			public static string Decrypt(string InputValue)
			{
				//Hard Code RSA Decrypt Key
				string DecryptKey = "<RSAKeyValue><Modulus>tyOPvDDu+6yTvfON47LM48xmFkhsqP8kEgVIkmHKvtp9RRTcwnRiSS+OtIRNQ1y4suc8xRiRCX7d7yiQAV2N7SGShETtIWMhQ1Kno/hqP+DNruQL62zDU2vdeZ9GCkbehxIQmUW2CCBDSzKrKkGfreFf3Y+eDZHZDMYI0kg6lD8=</Modulus><Exponent>AQAB</Exponent><P>87UWNEu/uz92WX8ODTqoa2cQHQ6LN5P99HbRblpSzTBvcdqUxcjx/7IIOoOKAA+pISHVnLxW2wTKxgInZt4zCQ==</P><Q>wGBfxfKREUFssKDk42ZiO2kDx/Hw+Cr8BdZmDeaPIkZ/+WLfSqLkFptTg7XJO6RBVThQMHAgz71R85PDkH53Bw==</Q><DP>2OVm4J42AtmFZDtu7xkwgX4VWjbyckF1OJhy5kre/J1J4kOOOsUPk+kH58PgExPdC47IRZldl8mZCkcqeCPzuQ==</DP><DQ>uBP/0LOYqEBINoLeQdHYMSz9Vzdk8rJ+0T8kDC0PzSZUkldPfmV7hz49nYw28ADuGxN1d8PzQZTQdBhySzMXxQ==</DQ><InverseQ>LzRQyO4xirsPgjRGWXNRfDJLFVEz0cx/xZM47B9ZEO11Q0nw8XJB7WoNWrWM6/22xHYnMa5nq0hevbC4H7vdWw==</InverseQ><D>tUlEfTvLNeKNlVjEugNCgrTQ0Xn75gY6RIRqZEzdj7Nkkb+nD+55ZIzpLJRSjz33r1DrfQdmewnU02tJsbBUThph0oXnKqAQPX9OotVcPY4cFxQk04aJCak67d0Qu/BZoWsIVCq+OW5WvyR7lChOS3FjhZW7LnJE6HbKP2RzZ+E=</D></RSAKeyValue>";
				System.Security.Cryptography.RSACryptoServiceProvider RSAProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
				System.Security.Cryptography.RSAParameters parameters = new System.Security.Cryptography.RSAParameters();
				RSAProvider.FromXmlString(DecryptKey);
				System.String encryptedBlock = "";
				System.Collections.Queue encryptedBlocks = new System.Collections.Queue();
				while (InputValue.Length != 0)
				{
					if (RSAProvider.KeySize == 1024)
					{
						encryptedBlock = InputValue.Substring(0, InputValue.IndexOf("=") + 1);
						encryptedBlocks.Enqueue(encryptedBlock);
						InputValue = InputValue.Remove(0, encryptedBlock.Length);
					}
					else
					{
						encryptedBlock = InputValue.Substring(0, InputValue.IndexOf("==") + 2);
						encryptedBlocks.Enqueue(encryptedBlock);
						InputValue = InputValue.Remove(0, encryptedBlock.Length);
					}
				}
				encryptedBlocks.TrimToSize();
				System.Int32 numberOfBlocks = encryptedBlocks.Count;
				string OutputValue = "";
				for (System.Int32 i = 1; i <= numberOfBlocks; i++)
				{
					encryptedBlock = (System.String)encryptedBlocks.Dequeue();
					OutputValue += System.Text.ASCIIEncoding.ASCII.GetString(RSAProvider.Decrypt(System.Convert.FromBase64String(encryptedBlock), true));
				}
				return OutputValue;
			}
			public static string Encrypt(string InputValue)
			{
				//Hard Code RSA Encrypt Key
				string EncryptKey = "<RSAKeyValue><Modulus>tyOPvDDu+6yTvfON47LM48xmFkhsqP8kEgVIkmHKvtp9RRTcwnRiSS+OtIRNQ1y4suc8xRiRCX7d7yiQAV2N7SGShETtIWMhQ1Kno/hqP+DNruQL62zDU2vdeZ9GCkbehxIQmUW2CCBDSzKrKkGfreFf3Y+eDZHZDMYI0kg6lD8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
				System.Security.Cryptography.RSACryptoServiceProvider RSAProvider = new System.Security.Cryptography.RSACryptoServiceProvider();
				System.Security.Cryptography.RSAParameters parameters = new System.Security.Cryptography.RSAParameters();
				RSAProvider.FromXmlString(EncryptKey);
				System.Int32 numberOfBlocks = (InputValue.Length / 32) + 1;
				System.Char[] charArray = InputValue.ToCharArray();
				System.Byte[][] byteBlockArray = new byte[numberOfBlocks][];
				System.Int32 incrementer = 0;
				for (System.Int32 i = 1; i <= numberOfBlocks; i++)
				{
					if (i == numberOfBlocks)
					{
						byteBlockArray[i - 1] = System.Text.ASCIIEncoding.ASCII.GetBytes(charArray, incrementer, charArray.Length - incrementer);
					}
					else
					{
						byteBlockArray[i - 1] = System.Text.ASCIIEncoding.ASCII.GetBytes(charArray, incrementer, 32);
						incrementer += 32;
					}
				}
				string OutputValue = "";
				for (System.Int32 j = 0; j < byteBlockArray.Length; j++)
				{
					OutputValue += System.Convert.ToBase64String(RSAProvider.Encrypt(byteBlockArray[j], true));
				}
				return OutputValue;
			}
		}
	
}
