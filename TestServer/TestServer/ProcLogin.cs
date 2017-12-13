using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWNetwork;
namespace TestServer
{
    public class ProcLogin : NetEventBase
    {
        public ProcLogin()
        {
            
        }

        public override void OnRawEvent(ushort msgID, byte[] datas)
        {
            base.OnRawEvent(msgID, datas);
        }

        public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        {
            switch (functionName)
            {
                case "C2S_Login":
                {
                    // query db 
                    string Account = datas["Account"];
                    string CheckPassword = datas["CheckPassword"];
                    string Password = datas["Password"];

                    // verify
                    if (Account != "Kevin" && Password != "123")
                    {
                        
                    }
                }
                    break;
                default:
                    break;

            }
        }


        public void DoResponse()
        {
            
        }

    }
}
