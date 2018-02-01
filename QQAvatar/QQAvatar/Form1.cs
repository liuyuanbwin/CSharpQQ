using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QQAvatar.Model;
using QQAvatar.Helpers;

namespace QQAvatar
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            GlobalVar.g_verifyCode = "";
            GlobalVar.g_sequence = 0;
            GlobalVar.MD5_32 = CoreTools.GetRandomKey(32);

            //判断是否本地保存有账号信息 没有则直接生成
            GlobalVar.g_tlv0105 = "01 05 00 30 " + "00 01 01 02 00 14 01 01 00 10 " + CoreTools.GetRandomKey(16) + "00 14 01 02 00 10 " + CoreTools.GetRandomKey(16);


            if(this.usernameBox.Text == string.Empty || this.passwordBox.Text == string.Empty)
            {
                MessageBox.Show("QQ或密码输入错误");
            }
        }
        private void Login()
        {
            GlobalVar.g_uin = this.usernameBox.Text;
            GlobalVar.g_pass = this.passwordBox.Text;
            GlobalVar.g_QQ = CoreTools.GetQQ_hex(usernameBox.Text);
            this.passwordBox.Text = GlobalVar.g_QQ;
        }
    }
}
