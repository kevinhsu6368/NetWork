using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWNetwork;

namespace TestClient
{
    public class Login : NetEventBase
    {

        //public const UInt16 MSGID_LOGIN = 1000;
        //public const UInt16 MSGID_Regist = 1001;

        public Login()
        {
            //onLogin = OnRawEvent;
        }

        public Login(string account, string pwd)
        {
            this.Account = account;
            this.Password = pwd;
        }

        //private NetEvent.OnRawEvent onLogin ;


        #region C2S
        public string Account;
        public string Password;
        public string Email;
        #endregion

        #region S2C

        public string PlayID;
        public string Photo;
        public string ErrorCord;
        public string GameServer;

        #endregion

        public void doLogin()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("Account", Account);
            data.Add("CheckPassword", "true");
            data.Add("Password", Password);

            Send("C2S_Login",data);
        }


        public void doRegister()
        {

        }

        public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        {
            switch (functionName)
            {
                case "S2C_Login":
                {
                    
                }
                    break;
                default:
                    break;
            }
       
        }

        public override void OnRawEvent(ushort msgID, byte[] datas)
        {
            base.OnRawEvent(msgID, datas);
        }
    }
}
