using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using JWNetwork;

namespace TestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            Init();
        }

        Login login = new Login();
        ForgetPassword forget = new ForgetPassword();
        

        private void Init()
        {
            c.onConnected = OnConnected;
            c.onDisconnected = OnDisconnected;
            c.onConnecteTimeout = OnConnecteTimeout;
            

            // register rpc 

            //c.RegRPCEvent(login,"S2C_Login", login.OnRPCEvent);
            c.RegRPCEvent(login, "C2S_Login", "S2C_Login");
            login.onLoginResult = OnLoginResult;

            c.RegRPCEvent(forget, "C2S_ForgetPassword", "S2C_ForgetPassword");
            forget.onS2CResult = s => { this.label_forget.Text = s; };


        }

        private void OnLoginResult(string s)
        {
            this.label_login_status.Text = s;
        }

        private void OnDisconnected(string flag)
        {
            label_connect_status.Text = "Disconnected";
            this.btn_Stop.Enabled = false ;
            this.btn_start.Enabled = true ;
        }

        private void OnConnecteTimeout()
        {
            label_connect_status.Text = "Connecte Timeout";
        }

        private void OnConnected()
        {
            label_connect_status.Text = "Connected";
            this.btn_Stop.Enabled = true;
            this.btn_start.Enabled = false;

        }

        AsynchronousClient c = new AsynchronousClient();

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                c.Start(this.txt_IP.Text, int.Parse(this.txt_Port.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }

        private void btn_sendMSG_Click(object sender, EventArgs e)
        {
            c.Send("我是Client");
        }

        private void btn_sendHex_Click(object sender, EventArgs e)
        {
            byte[] bs = new byte[] { 0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0A,0x0B,0x0C};
            c.Send(bs);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            c.Stop();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login.Account = txt_login_name.Text;
            login.Password = txt_login_pwd.Text;
            this.label_login_status.Text = "";

            login.MakeC2SData();
            login.ExecuteC2SEvent(true);
            //login.doLogin();
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {

        }

        private void btn_forget_Click(object sender, EventArgs e)
        {
            forget.Account = txt_forget_password.Text;
            forget.MakeC2SData();
            forget.ExecuteC2SEvent(true);
        }
    }
}
