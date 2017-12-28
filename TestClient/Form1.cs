using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            ImageMGR.Inst.Init();
        }

        AsynchronousClient gameServer = new AsynchronousClient(); // 連接 game server 的網路核心

        Registered registered = new Registered(); // 註冊 的 網路功能
        Login login = new Login(); // 登入的 網路功能
        ForgetPassword forget = new ForgetPassword(); // 忘記密碼的 網路功能
        GetUserPhoto getUserPhoto = new GetUserPhoto(); // 取得照片
        UploadPhoto uploadPhoto = new UploadPhoto();//上傳照片

        private void Init()
        {
            gameServer.packetType = PacketType.Len4BAndData;
            gameServer.onConnected = OnConnected;
            gameServer.onDisconnected = OnDisconnected;
            gameServer.onConnecteTimeout = OnConnecteTimeout;
            gameServer.onS2CError = s => this.label_s2c_error.Text = s;

            // register rpc 

            //登入
            gameServer.RegRPCEvent(login, "login_C2S", "login_S2C");
            login.onLoginResult = OnLoginResult;

            // 註冊
            gameServer.RegRPCEvent(registered, "registered_C2S", "registered_S2C");
            registered.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // 忘記密碼
            gameServer.RegRPCEvent(forget, "forgotPassword_C2S", "forgetPassword_S2C");
            forget.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // 取得照片
            gameServer.RegRPCEvent(getUserPhoto, "getUserPhoto_C2S", "getUserPhoto_S2C");
            getUserPhoto.onS2CResult = s => { this.label_s2c_error.Text = s; };
            getUserPhoto.onS2CResult += OnS2CResult_getUserPhoto;

            // 上傳照片
            gameServer.RegRPCEvent(uploadPhoto, "uploadPhoto_C2S", "uploadPhoto_S2C");
            uploadPhoto.onS2CResult = s => { this.label_s2c_error.Text = s; };

        }

        private void OnS2CResult_getUserPhoto(string s)
        {
            if (s.Contains("GetUserPhoto Success"))
            {
                //this.label_login_status.Text = "Get Photo";
                string[] ss = s.Split(',');
                foreach (string x in ss)
                {
                    if (!x.Contains("photo="))
                        continue;

                    byte[] bs = StringTools.HexStringToByteArray(x.Replace("photo=", ""));
                    MemoryStream ms = new MemoryStream(bs);

                    Image bmp = Bitmap.FromStream(ms);
                    this.pic_avartar.Image = bmp;
                    this.pic_avartar.SizeMode = PictureBoxSizeMode.Zoom;

                    ms.Close();
                }
            }
            else
            {
                this.label_login_status.Text = s;
            }
        }

        private void OnLoginResult(string s)
        {
            
            Console.WriteLine("OnLoginResult in Form1 at : " + DateTime.Now.ToString("HH:mm:ss.fff"));
            this.label_s2c_error.Text = s;
            string [] xx = s.Split(',');
            foreach (var x in xx)
            {
                if (x.Contains("photoId="))
                    continue;

            }
            /*
            if (s.Contains("photoId="))
            {
                
                //this.label_login_status.Text = "Get Photo";
                string[] ss = s.Split(':');
                byte[] bs = StringTools.HexStringToByteArray(ss[1]);
                MemoryStream ms = new MemoryStream(bs);

                Image bmp = Bitmap.FromStream(ms);
                this.pic_avartar.Image = bmp;
                this.pic_avartar.SizeMode = PictureBoxSizeMode.Zoom;

                ms.Close();
            }
 */
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

        

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                gameServer.Start(this.txt_IP.Text, int.Parse(this.txt_Port.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
            
        }

        private void btn_sendMSG_Click(object sender, EventArgs e)
        {
            gameServer.Send("我是Client");
        }

        private void btn_sendHex_Click(object sender, EventArgs e)
        {
            byte[] bs = new byte[] { 0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0A,0x0B,0x0C};
            gameServer.Send(bs);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            gameServer.Stop();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.label_login_status.Text = "";
            login.Account = txt_login_name.Text;
            login.Password = txt_login_pwd.Text;
            login.MakeC2SData();
            login.ExecuteC2SEvent(true);
        }

        private void btn_regist_Click(object sender, EventArgs e)
        {
            this.label_s2c_error.Text = "";
            registered.firstName = this.txt_first_name.Text;
            registered.lastName = this.txt_last_name.Text;
            registered.nickName = this.txt_nick_name.Text;
            registered.birthday = string.Format("{0}-{1}-{2}", new Random().Next(1950, 2010), new Random().Next(1, 12), new Random().Next(1, 30));
            registered.country = new Random().Next(100, 200).ToString();
            registered.pwd = this.txt_login_pwd.Text;
            registered.email = this.txt_email.Text;
            if (this.rbn_sex_woman.Checked)
                registered.gender = 0;
            else if (this.rbn_sex_man.Checked)
                registered.gender = 1;
            else
                registered.gender = 2;

            registered.photo = ImageMGR.Inst.GetImage(new Random().Next(0, 10)).hexData;

            registered.MakeC2SData();
            registered.ExecuteC2SEvent(true);
        }

        private void btn_forget_Click(object sender, EventArgs e)
        {
            forget.Account = txt_forget_password.Text;
            forget.MakeC2SData();
            forget.ExecuteC2SEvent(true);
        }

        private void btn_sendJSON_Click(object sender, EventArgs e)
        {
            Hashtable h = (Hashtable)MiniJSON.jsonDecode(txt_json.Text);

            Hashtable obj = (Hashtable)h["data"];//["friends"];
            ArrayList ss = (ArrayList)obj["friends"];
            foreach (Hashtable v in ss)
            {
                string id = v["id"].ToString();
                string name = v["name"].ToString();
            }
            gameServer.Send(txt_json.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            gameServer.Stop();
        }

        private void btn_get_user_photo_Click(object sender, EventArgs e)
        {
            getUserPhoto.photoId = (int)numericUpDown_photo_index.Value;
            getUserPhoto.MakeC2SData();
            getUserPhoto.ExecuteC2SEvent(true);
        }

        private void btn_upload_photo_Click(object sender, EventArgs e)
        {
            uploadPhoto.photo = ImageMGR.Inst.GetImage(new Random().Next(0, 10)).hexData;
            uploadPhoto.MakeC2SData();
            uploadPhoto.ExecuteC2SEvent(true);
        }
    }
}
