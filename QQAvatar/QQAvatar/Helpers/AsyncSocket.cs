using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanNiuSignal;
using SanNiuSignal.FileCenter;
using System.Net;
using System.Windows.Forms;

namespace QQAvatar.Helpers
{
    class AsyncSocket
    {
        public string m_IPAddress = string.Empty;
        public int m_Port = 0;

        #region TCP客户端区
        private ITxClient TxClient = null;
        public void StartListen(string host,int port)
        {
            try
            {
                TxClient = TxStart.startClient(host, port);
                TxClient.AcceptString += new TxDelegate<IPEndPoint, string>(acceptData);//接受数据回调
                TxClient.dateSuccess += new TxDelegate<IPEndPoint>(sendDataSuccess);//对方成功接受数据回调
                TxClient.EngineClose += new TxDelegate(clientClose);//用户端引擎关闭回调
                TxClient.EngineLost += new TxDelegate<string>(clientLost);//用户端非正常关闭回调
                TxClient.ReconnectionStart += new TxDelegate(reconnectStart);//当自动重连开始的回调
                TxClient.StartResult += new TxDelegate<bool, string>(connectResult);//登录完成回调
                //TxClient.Data_Max = 2048; 设置缓存大小
                TxClient.StartEngine();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        //接受文本数据回调
        private void acceptData(IPEndPoint end, string  str)
        {
            MessageBox.Show(str);
        }

        //当数据发送成功回调
        private void sendDataSuccess(IPEndPoint end)
        {
            MessageBox.Show("数据发送成功");
        }

        //客户端关闭回调
        private void clientClose()
        {
            MessageBox.Show("客户端已经关闭");
        }

        //客户端意外断开回调
        private void clientLost(string str)
        {
            MessageBox.Show("客户端意外断开 原因为: " + str);
        }

        //自动重连回调
        private void reconnectStart()
        {
            MessageBox.Show("10秒后自动重连开始!");
        }

        //连接结果回调
        private void connectResult(bool b, string str)
        {
            string result = string.Empty;
            if(b)
            {
                result = "成功";
            }
            else
            {
                result = "失败";
            }
            MessageBox.Show("连接结果: " + result + "原因: " + str);
        }

        //发送数据
        public void sendData(string data)
        {
            TxClient.sendMessage(data);
        }

        #endregion
        #region UDP 引擎区
        private IUdpTx udptx = null;
        private IPEndPoint _udpIPEndPoint = null;

        public IPEndPoint   UdpIPEndPoint
        {
            get
            {
                if(_udpIPEndPoint == null)
                {
                    IPAddress iPAddress = IPAddress.Parse(m_IPAddress);
                    _udpIPEndPoint = new IPEndPoint(iPAddress, m_Port);
                }
                return _udpIPEndPoint;
            }
        }


        //启动UDP
        public void startUDP(int port)
        {
            udptx = TxStart.startUdp();
            udptx.Port = port;//13091;//如果持续坚挺,在这里设置
            udptx.AcceptString += new TxDelegate<IPEndPoint, string>(UdpAcceptData);
            udptx.dateSuccess += new TxDelegate<IPEndPoint>(UdpDataSuccess);//接受成功数据回调
            udptx.EngineClose += new TxDelegate(clientClose);//客户端引擎关闭
            udptx.EngineLost += new TxDelegate<string>(clientLost);//客户端丢失连接
            udptx.StartEngine();
        }

        //监听UDP端口
        public void startUDPListen(int port)
        {
            udptx = TxStart.startUdp();
            udptx.Port = port;
            udptx.AcceptString += new TxDelegate<IPEndPoint, string>(UdpAcceptData);
            udptx.dateSuccess += new TxDelegate<IPEndPoint>(UdpDataSuccess);//接受成功数据回调
            udptx.EngineClose += new TxDelegate(clientClose);//客户端引擎关闭
            udptx.EngineLost += new TxDelegate<string>(clientLost);//客户端丢失连接
            udptx.StartEngine();
        }

        //接受客户端信息回调
        private void UdpAcceptData(IPEndPoint ipEndPoint, string str)
        {
            _udpIPEndPoint = ipEndPoint;
            MessageBox.Show("收到来自 " + ipEndPoint.ToString() + " 的信息: " + str);
        }

        //发送消息成功回调
        public void UdpDataSuccess(IPEndPoint ipEndPoint)
        {
            MessageBox.Show("已向 " + ipEndPoint.ToString() + " 发送成功!");
        }

        //发送UDP信息
        public void sendUDPData(string str)
        {
            udptx.sendMessage(UdpIPEndPoint, str);
        }

        public void sendUdpDataToIPEndPoint(IPEndPoint point)
        {
            udptx.sendMessage(point, "testtest");
        }
        #endregion
    }
}
