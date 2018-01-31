using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QQAvatar.Helpers
{
    class MiddleWare
    {
        //取十六进制文本
        public static string intToHexString(int num)
        {
            string result = string.Empty;
            byte[] bytes = BitConverter.GetBytes(num);
            for (int i = 0; i < bytes.Length; i ++)
            { 
                result += Convert.ToString(bytes[bytes.Length - 1 - i], 16).ToUpper();
            }
            return Regex.Replace(result,"^(0*)", "");
        }
    }
}
