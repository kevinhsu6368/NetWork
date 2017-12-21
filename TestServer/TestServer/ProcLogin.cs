using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

        public override void OnRPCEvent(AsynchronousServer.Client client,string functionName, Hashtable datas)
        {
            switch (functionName)
            {
                case "C2S_Login":
                    {
                        // query db 
                        string Account = datas["Account"].ToString();
                        string CheckPassword = datas["CheckPassword"].ToString();
                        string Password = datas["Password"].ToString();

                        // verify
                        if (Account == "Kevin" && Password == "123")
                        {
                            Hashtable data = new Hashtable();
                            data.Add("ErrorCode", "0");
                            data.Add("GameServer", "192.168.1.101:8800");
                            this.Send(client,"S2C_Login", data);
                        }
                        else
                        {
                            Hashtable data = new Hashtable();
                            data.Add("ErrorCode", "1");
                            data.Add("GameServer", "");
                            
                            int r = new Random().Next(0,3);
                            data.Add("Photo", ImageMGR.Inst.GetImage(r).hexData);
                            //data.Add("GameServer", "192.168.1.101:8800");
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
