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

        public override void OnRawEvent(AsynchronousServer.Client client, ushort msgID, byte[] datas)
        {
            base.OnRawEvent(client,msgID, datas);
        }

        public override void OnRPCEvent(AsynchronousServer.Client client,string functionName, Dictionary<string, string> datas)
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
                        if (Account == "Kevin" && Password == "123")
                        {
                            Dictionary<string, string> data = new Dictionary<string, string>();
                            data.Add("ErrorCode", "0");
                            data.Add("GameServer", "192.168.1.101^8800");
                            this.Send(client,"S2C_Login", data);
                        }
                        else
                        {
                            Dictionary<string, string> data = new Dictionary<string, string>();
                            data.Add("ErrorCode", "1");
                            data.Add("GameServer", "");
                            this.Send(client, "S2C_Login", data);
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
