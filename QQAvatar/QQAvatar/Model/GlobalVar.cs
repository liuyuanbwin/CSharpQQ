using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQAvatar.Model
{
    public class GlobalVar
    {
        public static string g_path;
        public static int g_port;
        public static string g_server;
        public static int g_IPSequence;
        public static string g_uin;
        public static string g_pass;
        public static string g_loginStatus;
        public static string MD52;
        public static string MD51;
        public static string MD5_32;
        public static string g_tlv0105;
        public static string g_sessionKey;
        public static string g_clientKey;
        public static string g_QQ;
        public static string g_verifyCode;
        public static int g_count;//重复更换验证码计数
        public static int g_sequence;//请求验证码的包序号
        public static string g_verifyToken;//检测验证码包Token
        public static string g_AddQQ;
        public static string g_addition;
        public static string g_skey;
        public static string g_criticalSection; //!结构多线程许可证
        public static string g_cookies;
        public static string g_gtk;
        public static string g_receiveData;
        public static string g_plugins; //!Plugin类型的
        public static string g_filename;


        //全局常量
        public static string j_head     = "02 ";
        public static string j_ver      = "37 13 ";
        public static string j_fixver   = "03 00 00 00 01 2E 01 00 00 68 52 00 00 00 00 ";
        public static string j_tail = " 03";

        public static string j__fixVer = "02 00 00 00 01 01 01 00 00 68 20 ";
        public static string j__0825data0 = "00 18 00 16 00 01 ";
        public static string j__0825date2 = "00 00 04 53 00 00 00 01 00 00 15 85 ";
        public static string j__0825key = "A4 F1 91 88 C9 82 14 99 0C 9E 56 55 91 23 C8 3D";
        public static string j_redirectionKey = "A8 F2 14 5F 58 12 60 AF 07 63 97 D6 76 B2 1A 3B";
        public static string j_publicKey = "02 6D 28 41 D2 A5 6F D2 FC 3E 2A 1F 03 75 DE 6E 28 8F A8 19 3E 5F 16 49 D3";
        public static string j_shareKey = "1A E9 7F 7D C9 73 75 98 AC 02 E0 80 5F A9 C6 AF";

        public static string j_0836fix = "06 A9 12 97 B7 F8 76 25 AF AF D3 EA B4 C8 BC E7 ";
        public static string j_00BaKey = "C1 9C B8 C8 7B 8C 81 BA 9E 9E 7A 89 E1 7A EC 94";
        public static string j_00BaFixKey = "69 20 D1 14 74 F5 B3 93 E4 D5 02 B3 71 1A CD 2A";

        public static string j_IamOnLine = "0A ";
        public static string j_QMe = "3C ";
        public static string j_IamLeave = "1E ";
        public static string j_IamBusy = "32 ";
        public static string j_DonotBoringMe = "46 ";
        public static string j_Invaisible = "28 ";

        public static string j_age_nolimit = "00";
        public static string j_age_16_22 = "02";
        public static string j_age_23_30 = "03";
        public static string j_age_31_40 = "04";
        public static string j_age_40 = "05";

        public static int j_GMEM_FIXED = 0;
        public static string j_encryptKey = "BA 42 FF 01 CF B4 FF D2 12 F0 6E A7 1B 7C B3 08";
        public static int j_PF_INET = 2;
        public static int j_SOCK_STREAM = 1;
        public static int j_SOCK_DGRAM = 2;
        public static int j_IPPROTO_TCP = 6;
        public static int j_IPPROTO_UDP = 17;
        public static UInt64 j_INTERNET_FLAG_RELOAD = 2147483648;
        public static int j_INTERNET_COOKIE_THIRD_PARTY = 16;
        public static int j_INTERNET_FLAG_NO_COOKIES = 524288;
        public static int j_INTERNET_FLAG_NO_CACHE_WRITE = 67108864;
        public static int j_INTERNET_FLAG_NO_AUTO_REDIRECT = 2097152;
        public static int j_INTERNET_FLAG_SECURE = 8388608;
        public static int j_INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP = 32768;
        public static int j_INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS = 16384;
        public static string j_const1 = "02 37 0F 08 36 2B 50 92 00 48 88 03 00 00 00 01 01 01 00 00 68 20 00 00 00 00 00 01 01 02 00 19 " +
            "02 39 4C 05 2D F1 B5 46 CE 42 17 65 10 59 BE C6 " +
            "5C 85 36 E0 6C 13 77 FD A8 00 00 00 10 B3 C2 F0 " +
            "83 E7 14 6C F5 1A 20 9D A9 70 07 6D EB FE BC 03 " +
            "10 B3 E7 8E ED 8E 8A EE 57 9F E1 CB E5 08 A6 BA " +
            "AA F3 AE 72 71 A4 65 02 C0 10 BC C6 4E A7 C9 AB " +
            "0F CC 98 97 4A FC FF BD B3 A4 F8 7F B2 62 7D EF " +
            "29 92 A0 88 C2 48 39 5C A9 B5 F2 1C 70 C9 ED B1 " +
            "C1 4E 5D 6D FA 10 51 9E 45 C1 C0 FE 34 02 08 AF " +
            "87 13 63 0F 32 AF 6C 5D 4C 2C B3 0F 13 37 A0 4A " +
            "95 A6 37 A8 B0 B7 8D 78 65 28 AA 6B ED F6 C5 28 " +
            "BA B0 75 FC F6 DB F6 19 50 95 BB 33 7F 7B 78 15 " +
            "AA E6 5E B2 A1 DF 03 82 6C 73 8E 7C F5 0E 99 DB " +
            "0C 66 DC 19 9F 86 EF 24 11 78 7B D0 4F 9D CB 02 " +
            "6F EC 6E D9 0A A3 4A 67 92 B2 21 80 62 54 4B FE " +
            "A7 A0 C5 AB C6 D8 CC 20 48 4E 24 39 25 70 29 97 " +
            "CA B4 31 37 B8 96 E2 C4 7A 5B A4 B4 97 95 8E 81 " +
            "78 F8 5C 8B AC B6 5F 2F 8F 6F B3 68 FC B6 E1 32 " +
            "12 CD 3F B4 96 1E 6D B4 D5 29 53 59 D2 BF 45 AC " +
            "C8 ED FA 7F 4A 0F 5D 0A B2 1D B7 B6 D0 3C DF F1 " +
            "DC B5 1F 2A 37 CB 76 B8 A5 F1 8B 37 16 E8 D5 9A " +
            "9D E0 C1 1D F5 09 80 65 07 B7 D1 B1 09 34 19 35 " +
            "B7 E8 E4 77 CC 7F 07 B2 93 62 FC 05 D5 19 09 9D " +
            "53 99 EB 7D 95 CB 27 86 B6 1B 1F 5E 7B E2 DC 92 " +
            "DB C1 3B A0 79 4B 3C D9 95 C3 FF F6 C8 70 EE D5 " +
            "2D F3 E2 B5 74 D8 87 B1 79 82 DE 4A 7B 12 B6 67 " +
            "A0 3F 4A E0 8D 10 5D 4A 0B 1B C7 15 FF CB 22 BF " +
            "AD B7 86 42 BD 3E 04 BE 13 62 F1 FB DD C9 2D 0C " +
            "03 72 31 2B A8 B2 2E 63 FF C9 14 69 23 13 94 5E " +
            "7F 8F 75 49 FC 42 4D 0A FD C0 2F FB 75 D8 B7 1F " +
            "51 67 2F B4 3F B8 FB E6 B8 FE C9 F3 16 09 04 34 " +
            "5E 95 B4 3B 48 2C 7F 61 BD 49 78 45 2F 11 84 DA " +
            "F2 B6 AD 18 76 03 60 BB 2D FA 55 A5 DC 60 1F 20 " +
            "A0 E1 CA 33 E5 C4 6F BE D6 45 A4 A8 F7 7F 6F AD " +
            "15 DB 03 B3 C3 FA 84 32 AB 9C BF 51 60 02 5A B4 " +
            "26 4C 69 65 70 03 B8 CE 48 D9 D2 B9 67 D8 DC 9E " +
            "09 EE F6 C9 2E C2 0E 7E 89 8C 70 F3 D5 D7 3E 62 " +
            "AA A7 A6 A2 57 5B C0 5F 80 53 7D D1 73 03";






    }
}
