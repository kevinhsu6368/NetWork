using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        AsynchronousClient c = new AsynchronousClient();

        private void btn_start_Click(object sender, EventArgs e)
        {
            c.Start("192.168.1.101",8888);
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
            
        }
    }
}
