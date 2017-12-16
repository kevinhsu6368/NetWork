using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using JWNetwork;

namespace TestClient
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
            this.c2s_data = new Dictionary<string, string>();
            this.c2s_data.Add("Account", Account);
            this.c2s_data.Add("CheckPassword", "true");
            this.c2s_data.Add("Password", Password);
 
        }
        #endregion




        public override void OnRPCEvent(Dictionary<string, string> datas)
        {
            try
            {
                string err = datas["ErrorCord"];
                if (err == "00000000")
                {
                    if (onLoginResult != null)
                        onLoginResult("Login Success ^ ^" + "\r\n" + "PlayerID : " + datas["PlayID"] + "\r\n" +
                                      "GameServer : " + datas["GaneServer"]);
                    Console.WriteLine("Login Success ^ ^");
                }
                else
                {
                    if (onLoginResult != null)
                        onLoginResult("Login Fail > <|||");

                    Console.WriteLine("Login Fail > <|||");
                }
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
