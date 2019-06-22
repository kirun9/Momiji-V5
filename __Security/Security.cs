using System.Security.Cryptography;
using System.Text;

namespace Momiji.Bot.V5.Modules
{
	public static class Security
	{
		public static bool CheckKey(string key, string hash)
		{
			var h = GetHash(key);
			return h.Equals(hash);
		}

		public static string GetHash(string key)
		{
			HashAlgorithm algorithm = SHA256.Create();
			var temp = algorithm.ComputeHash(Encoding.UTF8.GetBytes(key));
			StringBuilder builder = new StringBuilder();
			foreach (var b in temp)
			{
				builder.Append(b.ToString("X2"));
			}
			return builder.ToString();
		}
	}
}
