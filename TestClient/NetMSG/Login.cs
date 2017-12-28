using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace JWNetwork
{
    public class Login : NetEventBase
    {

        public Login()
        {

        }

        public Login(string account, string pwd)
        {
            this.Account = account;
            this.Password = pwd;
        }


        #region C2S_Login

        public string Account;
        public string Password;
        public string Email;

        #endregion

        #region S2C_Login

        public string PlayID;
        public string Photo;
        public string ErrorCord;
        public string GameServer;

        #endregion

        public Action<string> onLoginResult;


        #region 走預設 c2s 的處理流程 , 適合一個類別單一(C2S-S2C)功能
        public override void MakeC2SData()
        {
            // 指定 功能名稱
            //this.c2s_functionName = "C2S_Login";

            // 指定資料
            this.c2s_data = new Hashtable();
            this.c2s_data.Add("loginType",2);
            this.c2s_data.Add("email", Account);
            this.c2s_data.Add("pwd", Password);
        }
        #endregion




        public override void OnRPCEvent(Hashtable datas)
        {
            try
            {
                if (datas == null)
                {
                    if (onLoginResult != null)
                        onLoginResult("Login fail !!!");

                    Console.WriteLine("Login fail !!! ");
                    return;
                }

                int err = int.Parse(datas["rs"].ToString());

                switch (err)
                {
                    case 0:
                        if (onLoginResult != null)
                            onLoginResult(string.Format("Login Successed,uid={0},photoID={1}", datas["uid"].ToString()  , datas["photoId"].ToString() ));
                        break;
                    case 1:
                        if (onLoginResult != null)
                            onLoginResult("Login Fail : 帳號輸入錯誤或密碼輸入錯誤 !!!");
                        break;
                    case 2:
                        if (onLoginResult != null)
                            onLoginResult("Login Fail : 錯誤的登入類型 !!!");
                        break;
                    case 500:
                        if (onLoginResult != null)
                            onLoginResult("Login Fail : Server 錯誤 !!!");
                        break;
                    default:
                        break;
                }

                /*
                if (err == "00000000")
                {
                    if (onLoginResult != null)
                        onLoginResult("Login Success ^ ^" + "\r\n" + "PlayerID : " + datas["PlayID"] + "\r\n" +
                                      "GameServer : " + datas["GaneServer"]);
                    Console.WriteLine("Login Success ^ ^");
                }
                else
                {

                    if (datas.Contains("Photo"))
                    {
                        if (onLoginResult != null)
                            onLoginResult("Photo:" + datas["Photo"]);
                    }
                    else
                    {


                        if (onLoginResult != null)
                            onLoginResult("Login Fail > <|||");

                        Console.WriteLine("Login Fail > <|||");
                    }
 

                    
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\r\n" + e.StackTrace);
            }

        }

        //public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        //{
        //    base.OnRPCEvent(functionName, datas);
        //}


        //public void doLogin()
        //{
        //    Dictionary<string, string> data = new Dictionary<string, string>();
        //    data.Add("Account", Account);
        //    data.Add("CheckPassword", "true");
        //    data.Add("Password", Password);

        //    Send("C2S_Login",data);
        //}

        //public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        //{
        //    switch (functionName)
        //    {
        //        case "S2C_Login":
        //        {

        //        }
        //            break;
        //        default:
        //            break;
        //    }

        //}

    }
}
