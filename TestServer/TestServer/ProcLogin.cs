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


        public void DoResponse()
        {
            
        }

    }
}
