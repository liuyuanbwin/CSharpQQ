using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using QQAvatar.Model;
using QQAvatar.Helpers;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;

namespace QQAvatar
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            InitUDP();
        }

        private IPEndPoint ipLocalPoint;
        private EndPoint RemotePoint;
        private Socket mySocket;
        private bool RunningFlag = false;

        [DllImport("lye.dll")]
        static extern IntPtr GetLoginUDPData(string qq,string pwd);

        [DllImport("lye.dll")]
        static extern IntPtr Getg_server();

        [DllImport("lye.dll")]
        static extern IntPtr Dispose_0825(string data,string flag,int length);

        private  string GetLoginUDPStr(string qq, string pwd)
        {
            string eString = eToString(GetLoginUDPData(qq, pwd));
            return eString.Substring(0, 440);
        }

         void InitUDP()
        {
            int port;
            IPAddress ip;
            ip = getValidIP("0.0.0.0");
            port = getValidPort("8000");
            ipLocalPoint = new IPEndPoint(ip, port);
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.Bind(ipLocalPoint);

            //得到目标ip
             ip = getValidIP("163.177.87.199");
            port = getValidPort("8000");
            IPEndPoint ipep = new IPEndPoint(ip, port);
            RemotePoint = (EndPoint)(ipep);

            RunningFlag = true;
            Thread thread = new Thread(new ThreadStart(this.ReceiveHandle));
            thread.Start();
        }
           
        private int getValidPort(string port)
        {
            int lport;
            //测试端口号是否有效  
            try
            {
                //是否为空  
                if (port == "")
                {
                    throw new ArgumentException("端口号无效，不能启动DUP");
                }
                lport = System.Convert.ToInt32(port);
            }
            catch (Exception e)
            {
                //ArgumentException,   
                //FormatException,   
                //OverflowException  
                MessageBox.Show("无效的端口号：" + e.ToString());
                return -1;
            }
            return lport;
        }

        private  IPAddress getValidIP(string ip)
        {
            IPAddress lip = null;
            //测试IP是否有效  
            try
            {
                //是否为空  
                if (!IPAddress.TryParse(ip, out lip))
                {
                    throw new ArgumentException(
                        "IP无效，不能启动DUP");
                }
            }
            catch (Exception e)
            {
                //ArgumentException,   
                //FormatException,   
                //OverflowException  
                MessageBox.Show("无效的IP：" + e.ToString() + "\n");
                return null;
            }
            return lip;
        }

        //定义一个委托  
        public delegate void MyInvoke(string strRecv);
        private void ReceiveHandle()
        {
            //接收数据处理线程  
            string msg;
            byte[] data = new byte[1024];
            MyInvoke myI = new MyInvoke(UpdateMsgTextBox);
            while (RunningFlag)
            {
                if (mySocket == null || mySocket.Available < 1)
                {
                    Thread.Sleep(200);
                    continue;
                }
                //跨线程调用控件  
                //接收UDP数据报，引用参数RemotePoint获得源地址  
                int rlen = mySocket.ReceiveFrom(data, ref RemotePoint);
                msg = Encoding.Default.GetString(data, 0, rlen);

                MessageBox.Show("###收到消息->" + ToHexString(data) + ".. " + RemotePoint.ToString() + rlen);
                DataArrive(data,rlen);
            }
        }

        private void DataArrive(byte[] data,int dataLength)
        {
            string dataString = ToHexString(data);
            string trimString = dataString.Substring(0, dataLength*3 -1 );
            string flag = dataString.Substring(9, 11);

            //0825 touch包
            if(flag .Equals( "08 25 31 01") )
            {
                string Str_0825 = eToString(Dispose_0825(trimString, flag, dataLength));

                byte[] touchdata = strToToHexByte(Str_0825);

                string ip = eToString(Getg_server());
                IPEndPoint ipep = new IPEndPoint(getValidIP(ip), 8000);
                RemotePoint = (EndPoint)(ipep);

                mySocket.SendTo(touchdata, touchdata.Length, SocketFlags.None, RemotePoint);
            }

            if (flag.Equals("08 25 31 02"))
            {
                string Str_0825 = eToString(Dispose_0825(trimString, flag, dataLength));

                byte[] touchdata = strToToHexByte(Str_0825);

                string ip = eToString(Getg_server());
                IPEndPoint ipep = new IPEndPoint(getValidIP(ip), 8000);
                RemotePoint = (EndPoint)(ipep);

                mySocket.SendTo(touchdata, touchdata.Length, SocketFlags.None, RemotePoint);
                MessageBox.Show("收到了 02 包 " + dataString);
            }

        }

       

        //把字符串转为 0xXX 形式的字符串
        string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2") + " ");
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        private void UpdateMsgTextBox(string msg)
        {
            //接收数据显示  
            MessageBox.Show(msg + "\n");
        }

        //将e语言返回的字节集转成 string
        private  string eToString(IntPtr intPtr)
        {
            IntPtr origin = intPtr;
            string originStr = ("" + Marshal.PtrToStringAnsi(intPtr));

    
            string[] s = originStr.Split(new char[] { '#' });

            Regex rgx = new Regex("[^A-F0-9\\.\u0020]");
            return rgx.Replace(s[0], "");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            /*
                GlobalVar.g_verifyCode = "";
                GlobalVar.g_sequence = 0;
                GlobalVar.MD5_32 = eToString(GetRandomKey(32));
                GlobalVar.g_tlv0105 = "01 05 00 30 " + "00 01 01 02 00 14 01 01 00 10 " + eToString(GetRandomKey(16)) + "00 14 01 02 00 10 " + eToString(GetRandomKey(16));
                */

            if (this.usernameBox.Text == string.Empty || this.passwordBox.Text == string.Empty)
            {
                MessageBox.Show("QQ或密码输入错误");
            }
            else
            {
               Login();
            }
        }

        //字节字符串转成 byte[]
        private  byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        private void Login()
        {
            try
            {
                IntPtr s = GetLoginUDPData(this.usernameBox.Text, this.passwordBox.Text);
                string result = GetLoginUDPStr(this.usernameBox.Text, this.passwordBox.Text);//eToString( getfir (this.usernameBox.Text, this.passwordBox.Text));
                IntPtr ipdata = Getg_server();
                string ip = eToString(Getg_server());
                MessageBox.Show(result +  ip);
                byte[] data = strToToHexByte(result);
                IPEndPoint ipep = new IPEndPoint(getValidIP(ip), 8000);
                RemotePoint = (EndPoint)(ipep);

                mySocket.SendTo(data, data.Length, SocketFlags.None, RemotePoint);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
