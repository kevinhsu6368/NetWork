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
                case "login_C2S":
                    {
                        int loginType = int.Parse(datas["loginType"].ToString());

                        switch (loginType)
                        {
                            case 0: // Guest
                                break;
                            case 1: // FB
                                break;
                            case 2: // custom
                                string email = datas["email"].ToString();
                                string pwd = datas["pwd"].ToString();

                                // query db 
                                Hashtable hS2C = SQLMGR.Inst.CustomLogin(email, pwd);
                                if (hS2C == null)
                                {
                                    hS2C = new Hashtable();
                                    hS2C.Add("rs", 1);
                                }
                                else
                                {
                                    hS2C.Add("rs", 0);
                                }
                                hS2C.Add("loginType", loginType);

                                this.Send(client, "login_S2C", hS2C);

                                break;
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
