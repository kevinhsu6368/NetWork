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

        AddPartner addPartner = new AddPartner();
        AddPartnerRequest addPartnerRequest = new AddPartnerRequest();
        AddPartnerResponse addPartnerResponse = new AddPartnerResponse();
        GetPartnersList getPartnersList = new GetPartnersList();
        RemovePartner removePartner = new RemovePartner();
        UpdatePhoto updatePhoto = new UpdatePhoto();
        GetAllUserPhoto getAllUserPhoto = new GetAllUserPhoto();
        SetUserPhoto setUserPhoto = new SetUserPhoto();
        CreateRoomInfo createRoomInfo = new CreateRoomInfo();
        RemoveRoomInfo removeRoomInfo = new RemoveRoomInfo();
        InvitedPartnerToRoom invitedPartnerToRoom = new InvitedPartnerToRoom();
        JoinRoomRequest joinRoomRequest = new JoinRoomRequest();
        JoinRoom joinRoom = new JoinRoom();
        Logout logout = new Logout();

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

            //登入
            gameServer.RegRPCEvent(logout, "logout_C2S", "logout_S2C");
            logout.onS2CResult = s => { this.label_s2c_error.Text = s; };

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

            // 更新照片
            gameServer.RegRPCEvent(updatePhoto, "updatePhoto_C2S", "updatePhoto_S2C");
            updatePhoto.onS2CResult = s => { this.label_s2c_error.Text = s; };


            // 更新照片
            gameServer.RegRPCEvent(setUserPhoto, "setUserPhoto_C2S", "setUserPhoto_S2C");
            setUserPhoto.onS2CResult = s => { this.label_s2c_error.Text = s; };


            // 上傳照片
            gameServer.RegRPCEvent(getAllUserPhoto, "getAllUserPhoto_C2S", "getAllUserPhoto_S2C");
            getAllUserPhoto.onS2CResult = s => { this.label_s2c_error.Text = s; };
            getAllUserPhoto.onS2CResultWithData = (s, data) =>
            {
                int total = int.Parse(data["total"].ToString());
                if (total == 0)
                    return;
                int number = int.Parse(data["number"].ToString());
                long uid = long.Parse(data["uid"].ToString());
                long photoId = long.Parse(data["photoId"].ToString());
                string photo = data["photo"].ToString();

                PictureBox[] pics = {this.pic_photo1, pic_photo2, pic_photo3, pic_photo4, pic_photo5, pic_photo6};
                Label[] ids =
                {
                    label_photoId_1, label_photoId_2, label_photoId_3, label_photoId_4, label_photoId_5,
                    label_photoId_6
                };

                if (number <= pics.Length)
                {
                    byte[] bs = StringTools.HexStringToByteArray(photo);
                    MemoryStream ms = new MemoryStream(bs);

                    Image bmp = Bitmap.FromStream(ms);
                    pics[number-1].Image = bmp;
                    pics[number-1].SizeMode = PictureBoxSizeMode.Zoom;

                    ms.Close();

                    ids[number-1].Text = photoId.ToString();
                }

            };


            // addPartner
            gameServer.RegRPCEvent(addPartner, "addPartner_C2S", "addPartner_S2C");
            addPartner.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // addPartnerRequest
            gameServer.RegRPCEvent(addPartnerRequest, "addPartnerRequest_C2S", "addPartnerRequest_S2C");
            addPartnerRequest.onS2CResult = s => { this.label_s2c_error.Text = s; };
            addPartnerRequest.onS2CResultWithData = (s, hashtable) =>
            {
                this.txtPartnerInviterUID.Text = hashtable["inviter"].ToString();
                this.txtPartnerInviterName.Text = hashtable["nickName"].ToString();
            };

            // addPartnerResponse
            gameServer.RegRPCEvent(addPartnerResponse, "addPartnerResponse_C2S", "addPartnerResponse_S2C");
            addPartnerResponse.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // getPartnersList
            gameServer.RegRPCEvent(getPartnersList, "getPartnersList_C2S", "getPartnersList_S2C");
            getPartnersList.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // removePartner
            gameServer.RegRPCEvent(removePartner, "removePartner_C2S", "removePartner_S2C");
            removePartner.onS2CResult = s => { this.label_s2c_error.Text = s; };


            /*
int rs  0 = 成功建立
array<Long> uids    遊戲室目前玩家uid list EX. [111, 222, 333]
String roomId  遊戲室編號
int roomType    1 = 01game,2 = cricket,3 = count up,4 = bull hunter,5 = match
int gameType    0 = SDB,1 = Online
int select  依據roomType會有各種不同的對應,EX.01game就是選擇1 = 301.2 = 501.3 = 701...依此類推
int playerAmount    遊戲人數 1,2,3,4
long owner   遊戲室擁有者
*/


            // create  room 
            gameServer.RegRPCEvent(createRoomInfo, "createRoomInfo_C2S", "createRoomInfo_S2C");
            createRoomInfo.onS2CResult = s => { this.label_s2c_error.Text = s; };
            createRoomInfo.onS2CResultWithData = (s, data) =>
            {
                this.label_s2c_error.Text = s;
                string roomId = data["roomId"].ToString();
                this.txtRoomID.Text = roomId;
                int roomType = int.Parse(data["roomType"].ToString());
                int gameType = int.Parse(data["gameType"].ToString());
                int select = int.Parse(data["select"].ToString());
                int playerAmount = int.Parse(data["playerAmount"].ToString());
                long owner = int.Parse(data["owner"].ToString());
                ArrayList uids = (ArrayList) data["uids"];

                this.label_createRoom_select.Text = select.ToString();
                this.label_createRoom_gameType.Text = gameType.ToString();
                this.label_createRoom_playerCount.Text = playerAmount.ToString();
                this.label_createRoom_roomType.Text = roomType.ToString();
                this.label_Room_UIDS.Text = "";
                foreach (double uid in uids)
                {
                    this.label_Room_UIDS.Text += string.Format("{0},", uid);
                   
                }
            };

            // remove room 
            gameServer.RegRPCEvent(removeRoomInfo, "removeRoomInfo_C2S", "removeRoomInfo_S2C");
            removeRoomInfo.onS2CResult = s => { this.label_s2c_error.Text = s; };

            // invited Partner To Room
            gameServer.RegRPCEvent(invitedPartnerToRoom, "invitedPartnerToRoom_C2S", "invitedPartnerToRoom_S2C");
            invitedPartnerToRoom.onS2CResult = s => { this.label_s2c_error.Text = s; };
            
            // invited Partner To Room
            gameServer.RegRPCEvent(joinRoomRequest, "joinRoomRequest_C2S", "joinRoomRequest_S2C");
            joinRoomRequest.onS2CResultWithData = (s,datas) =>
            {
                this.label_s2c_error.Text = s;

                long inviter = long.Parse(datas["inviter"].ToString());
                string nickName = datas["nickName"].ToString();
                long roomType = long.Parse(datas["roomType"].ToString());
                long select = long.Parse(datas["select"].ToString());
                long playAmount = long.Parse(datas["playAmount"].ToString());
                long gameType = long.Parse(datas["gameType"].ToString());
                string roomId = datas["roomId"].ToString();
                string[] roomTypeNames = { "Zero One", "cricket", "count up", "bull hunter", "match", "Practice", "Party" };
                string roomInfo = roomTypeNames[roomType - 1];

                joinRoom.roomId = roomId;
                joinRoom.inviterUid = inviter;
                
                if (MessageBox.Show( s, "joinRoomRequest", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // 回應 同意
                    joinRoom.flag = 0;
                }
                else
                {
                    // 回應 不同意
                    joinRoom.flag = 1;
                }

                joinRoom.MakeC2SData();
                joinRoom.ExecuteC2SEvent(true);
            };

            // joinRoom
            gameServer.RegRPCEvent(joinRoom, "joinRoom_C2S", "joinRoom_S2C");
            joinRoom.onS2CResult = s =>
            {
                this.label_s2c_error.Text = s;
            };
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
            this.pic_avartar.Image = null;
            this.label_s2c_error.Text = "---";
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

            if (isWillLoginNotStart)
            {
                isWillLoginNotStart = false;
                this.btn_login_Click(this,null);
            }

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

        private bool isWillLoginNotStart = false;

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (this.btn_start.Enabled == true)
            {
                isWillLoginNotStart = true;
                this.btn_start_Click(this,null);
                return;
            }

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
            registered.pwd = this.txt_pwd.Text;
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

        private void btn_partner_add_Click(object sender, EventArgs e)
        {
            addPartner.email = txt_partner_email.Text;
            addPartner.MakeC2SData();
            addPartner.ExecuteC2SEvent(true);
        }

        private void btn_Partner_response_agree_Click(object sender, EventArgs e)
        {
            addPartnerResponse.inviterUid = txtPartnerInviterUID.Text;
            addPartnerResponse.isAgree = true;
            addPartnerResponse.MakeC2SData();
            addPartnerResponse.ExecuteC2SEvent(true);

        }

        private void btn_Partner_response_deny_Click(object sender, EventArgs e)
        {
            addPartnerResponse.inviterUid = txtPartnerInviterUID.Text;
            addPartnerResponse.isAgree = false;
            addPartnerResponse.MakeC2SData();
            addPartnerResponse.ExecuteC2SEvent(true);
        }

        private void btn_update_photo_Click(object sender, EventArgs e)
        {
            updatePhoto.photoId = numericUpDown_update_photo.Value.ToString();
            updatePhoto.photo = ImageMGR.Inst.GetImage(new Random().Next(0, 10)).hexData;
            updatePhoto.MakeC2SData();
            updatePhoto.ExecuteC2SEvent(true);
        }

        private void btn_getAllPhoto_Click(object sender, EventArgs e)
        {
            this.pic_photo1.Image = null;
            this.pic_photo2.Image = null;
            this.pic_photo3.Image = null;
            this.pic_photo4.Image = null;
            this.pic_photo5.Image = null;
            this.pic_photo6.Image = null;
            this.label_photoId_1.Text = "---";
            this.label_photoId_2.Text = "---";
            this.label_photoId_3.Text = "---";
            this.label_photoId_4.Text = "---";
            this.label_photoId_5.Text = "---";
            this.label_photoId_6.Text = "---";

            getAllUserPhoto.MakeC2SData();
            getAllUserPhoto.ExecuteC2SEvent(true);
        }

        private void btn_use_photo_Click(object sender, EventArgs e)
        {
            setUserPhoto.photoId = (long)numericUpDown_use_photo.Value;
            
            setUserPhoto.MakeC2SData();
            setUserPhoto.ExecuteC2SEvent(true);
        }

        private void btn_create_room_Click(object sender, EventArgs e)
        {
            this.txtRoomID.Text = "";
            this.label_createRoom_select.Text = "...";
            this.label_createRoom_playerCount.Text = "...";
            this.label_createRoom_gameType.Text = "...";
            this.label_createRoom_select.Text = "...";

            createRoomInfo.playerAmount = cbx_createRoom_playerCount.SelectedIndex + 1;
            createRoomInfo.gameType = cbx_createRoom_gameType.SelectedIndex;
            createRoomInfo.roomType = cbx_createRoom_roomType.SelectedIndex+1;
            createRoomInfo.select = cbx_createRoom_select.SelectedIndex+1;
            createRoomInfo.MakeC2SData();
            createRoomInfo.ExecuteC2SEvent(true);
        }

        private void btn_delete_room_Click(object sender, EventArgs e)
        {
            removeRoomInfo.roomId = txtRoomID.Text;
            removeRoomInfo.MakeC2SData();
            removeRoomInfo.ExecuteC2SEvent(true);
        }

        private void btn_invite_partner_to_game_Click(object sender, EventArgs e)
        {
            invitedPartnerToRoom.roomId = txtRoomID.Text;
            invitedPartnerToRoom.partnerUid = long.Parse(txt_partnerUID_to_Game.Text);
            invitedPartnerToRoom.MakeC2SData();
            invitedPartnerToRoom.ExecuteC2SEvent(true);
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            logout.MakeC2SData();
            logout.ExecuteC2SEvent(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
