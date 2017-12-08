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
        }

        private AsynchronousServer server = new AsynchronousServer();

        private void btn_start_Click(object sender, EventArgs e)
        {
            server.Start();

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
