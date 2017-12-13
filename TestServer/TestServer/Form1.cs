using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Reflection;
using JWNetwork;
namespace TestServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            Init();

        }

        void Init()
        {
            server.RegRPCEvent(login, "C2S_Login", login.OnRPCEvent);
        }

        ProcLogin login = new ProcLogin();

        private AsynchronousServer server = new AsynchronousServer();

        private void btn_start_Click(object sender, EventArgs e)
        {
            server.Start(int.Parse(txt_max_count.Text),int.Parse(txt_Port.Text));
            server.onAcceptClient = OnAcceptClient;
            server.onKillClient = OnKillClient;
        }

        private void OnKillClient(object client)
        {
            foreach (ListViewItem v in lv_clients.Items)
            {
                if(v.Tag == client)
                    lv_clients.Items.Remove(v);
            }
            UpdateLsClientNO();
        }

        private void OnAcceptClient(object client)
        {
            AsynchronousServer.Client c = (AsynchronousServer.Client) client;
            ListViewItem lvItem = new ListViewItem(new string[] {"---",c.ip,"---"});
            lvItem.Tag = c;

            this.lv_clients.Items.Add(lvItem);

            UpdateLsClientNO();
        }

        public void UpdateLsClientNO()
        {
            for (int i = 0; i < this.lv_clients.Items.Count; i++)
            {
                this.lv_clients.Items[i].Text = (i + 1).ToString();
            }
        }


        private void btn_Stop_Click(object sender, EventArgs e)
        {
            server.Stop();

        }

        private void btn_SendMSG_Click(object sender, EventArgs e)
        {
            string txt = this.txt_send.Text; // "這個是 Test !!!";
            server.SendMsgToAll(txt);
 
        }



        private void btn_SendHex_Click(object sender, EventArgs e)
        {
            string txt = this.txt_sendHex.Text; // "這個是 Test !!!";
            byte[] bs = StringTools.HexStringToByteArray(txt);
            //byte[] bs = new byte[] { 0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a};

            server.SendRawDataToAll(bs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.timer1.Stop();

            server.DeleteClients();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Type t = typeof(IBullHunterPlayer);
            PropertyInfo [] ps = t.GetProperties();
        }

        private void btn_responseLogin_Click(object sender, EventArgs e)
        {
            //server.SendPacket();
        }
    }
}
