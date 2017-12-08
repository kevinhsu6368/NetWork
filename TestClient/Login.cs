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

        public const UInt16 MSGID_LOGIN = 1000;
        public const UInt16 MSGID_Regist = 1001;

        public Login()
        {
            //onLogin = OnRawEvent;
        }

        public Login(string name, string pwd)
        {
            this.Name = name;
            this.Pwd = pwd;
        }

        //private NetEvent.OnRawEvent onLogin ;
        
        

        public string Name;
        public string Pwd;
        public string Email;

        public void doLogin()
        {
            string str = Name + "^" + Pwd;
            byte[] bs = Encoding.UTF8.GetBytes(str);
            Send(MSGID_LOGIN, bs);
        }


        public void doRegister()
        {
            string str = Name + "^" + Pwd + "^" + Email;
            byte[] bs = Encoding.UTF8.GetBytes(str);
            Send(MSGID_LOGIN, bs);
        }

        public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        {
            base.OnRPCEvent(functionName, datas);

        }

        public override void OnRawEvent(ushort msgID, byte[] datas)
        {
            base.OnRawEvent(msgID, datas);
        }
    }
}
