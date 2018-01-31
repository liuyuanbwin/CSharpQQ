using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQAvatar.Helpers
{
    class CoreTools
    {
        public static string GetRandomKey(int length)
        {
            string ret = string.Empty;
            int i = length;
            while ((i--) > 0)
            {
                Random rd = new Random();
                ret = ret + MiddleWare.intToHexString(rd.Next(1, 255));
            }
            return ret;
        }

        public static string GetQQ_hex(string qqNum)
        {
            //长整数型 Int64
            Int64 num;
            string numtext;
            byte[] numtext_7; //备注 0000000
            string n_0_2;
            string n_3_2;
            string n_5_2;
            string n_7_2;
            string n_kg;

            num = Convert.ToInt64(qqNum);
            numtext_7 = System.BitConverter.GetBytes(num);




        }
    }
}
