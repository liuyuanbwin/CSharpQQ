using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQAvatar.Helpers
{
    class SystemScale
    {
        public static string DecToHex(int n)
        {
            string hex = string.Empty;
            if(n < 256)
            {
                string str = "0" + MiddleWare.intToHexString(n);
                return str.Substring(str.Length - 2);
            }

            if(n >= 256)
            {
                string str = "0" + MiddleWare.intToHexString(n);
                hex = str.Substring(str.Length - 4);
                return hex.Substring(0, 2) + " " + hex.Substring(hex.Length - 2);
            }
            return string.Empty;
        }
    }
}
