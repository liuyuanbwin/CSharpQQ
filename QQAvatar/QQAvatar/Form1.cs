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
        static extern IntPtr GetRandomKey(int length);

        [DllImport("lye.dll")]
        static extern IntPtr GetQQ_hex(string qqnum);

        [DllImport("lye.dll")]
        static extern IntPtr GetServerIP();

        [DllImport("lye.dll")]
        static extern string GetFirstUDPText(string qqhex,string ip);

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
            //ip = getValidIP("192.168.199.145");
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
                MessageBox.Show("###收到消息->" + ToHexString(data) + ".. " + RemotePoint.ToString());

            }
        }

        string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "

        {
            string hexString = string.Empty;

            if (bytes != null)

            {

                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)

                {

                    strB.Append(bytes[i].ToString("X2"));

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

        private  string eToString(IntPtr intPtr)
        {
            IntPtr origin = intPtr;

            return ("" + Marshal.PtrToStringAnsi(intPtr));
        }


        private void loginButton_Click(object sender, EventArgs e)
        {

                GlobalVar.g_verifyCode = "";
                GlobalVar.g_sequence = 0;
                GlobalVar.MD5_32 = eToString(GetRandomKey(32));
                GlobalVar.g_tlv0105 = "01 05 00 30 " + "00 01 01 02 00 14 01 01 00 10 " + eToString(GetRandomKey(16)) + "00 14 01 02 00 10 " + eToString(GetRandomKey(16));

            if (this.usernameBox.Text == string.Empty || this.passwordBox.Text == string.Empty)
            {
                MessageBox.Show("QQ或密码输入错误");
            }
            else
            {
               Login();
            }
        }
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
                
                GlobalVar.g_uin = this.usernameBox.Text;
                GlobalVar.g_pass = this.passwordBox.Text;
                GlobalVar.g_QQ =  eToString(GetQQ_hex(GlobalVar.g_uin));
                GlobalVar.g_server = eToString(GetServerIP());
                string result = GetFirstUDPText("119077905", "");
                MessageBox.Show(result);


                byte[] data = strToToHexByte(result);

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
