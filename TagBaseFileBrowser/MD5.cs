using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagBaseFileBrowser
{
    internal static class MD5
    {
        /// <summary>
        /// To MD5.
        /// </summary>
        /// <remarks>From https://ithelp.ithome.com.tw/articles/10190215 </remarks>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            using (var cryptoMD5 = System.Security.Cryptography.MD5.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(str);
                var hash = cryptoMD5.ComputeHash(bytes);
                var md5 = BitConverter.ToString(hash).
                    Replace("-", String.Empty).
                    ToUpper();
                return md5;
            }
        }
    }
}