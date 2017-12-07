using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public class Login : NetEventBase 
    {
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

        


        public override void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        {
            //throw new NotImplementedException();
        }

        public override void OnRawEvent(ushort msgID, byte[] datas)
        {
            //throw new NotImplementedException();
        }
    }
}
