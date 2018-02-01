using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QQAvatar.Model;
using QQAvatar.Helpers;

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

            n_0_2 = SystemScale.DecToHex(numtext_7[0]);
            n_3_2 = SystemScale.DecToHex(numtext_7[1]);
            n_5_2 = SystemScale.DecToHex(numtext_7[2]);
            n_7_2 = SystemScale.DecToHex(numtext_7[3]);
            n_kg = n_7_2 + " " + n_5_2 + " " + n_3_2 + " " + n_0_2 + " ";
            return n_kg;
        }
        public static string GetServerIP()
        {
            string IP = string.Empty;
            if(GlobalVar.g_IPSequence > 8)
            {
                GlobalVar.g_IPSequence = 1;
            }
            if(GlobalVar.g_IPSequence == 0)
            {
                IP = MiddleWare.HostNameToIP("183.60.56.29");
            }
            if (GlobalVar.g_IPSequence == 1)
            {
                IP = MiddleWare.HostNameToIP("sz2.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 2)
            {
                IP = MiddleWare.HostNameToIP("sz3.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 3)
            {
                IP = MiddleWare.HostNameToIP("sz4.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 4)
            {
                IP = MiddleWare.HostNameToIP("sz5.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 5)
            {
                IP = MiddleWare.HostNameToIP("sz6.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 6)
            {
                IP = MiddleWare.HostNameToIP("183.60.56.29");
            }
            if (GlobalVar.g_IPSequence == 7)
            {
                IP = MiddleWare.HostNameToIP("sz8.tencent.com");
            }
            if (GlobalVar.g_IPSequence == 8)
            {
                IP = MiddleWare.HostNameToIP("sz9.tencent.com");
            }
            return IP;
        }
    }
}
