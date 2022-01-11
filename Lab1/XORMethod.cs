using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab1
{
    internal static class XORMethod
    {
        public static string EncryptDecrypt(string text, int key)
        {
            StringBuilder inSb = new StringBuilder(text);

            StringBuilder outSb = new StringBuilder(text.Length);

            char c;

            for (int i = 0; i < text.Length; i++)
            {

                c = inSb[i];

                c = (char)(c ^ key);

                outSb.Append(c);

            }

            return outSb.ToString();
        }
        

    }
}
