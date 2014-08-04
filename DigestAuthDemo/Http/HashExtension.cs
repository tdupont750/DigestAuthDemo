using System.Security.Cryptography;
using System.Text;

namespace DigestAuthDemo.Http
{
    public static class HashExtension
    {
        public static string ToMd5Hash(this byte[] bytes)
        {
            var sb = new StringBuilder();
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(bytes);

            foreach (var b in hash)
                sb.AppendFormat("{0:x2}", b);

            return sb.ToString();
        }

        public static string ToMd5Hash(this string inputString)
        {
            var bytes = Encoding.UTF8.GetBytes(inputString);
            return bytes.ToMd5Hash();
        }
    }
}