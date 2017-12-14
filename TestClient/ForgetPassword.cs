using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;

namespace TestClient
{
    public class ForgetPassword : NetEventBase
    {
   

        public string Account;

        public Action<string> onS2CResult;


        public override void MakeC2SData()
        {
            this.c2s_data = new Dictionary<string, string>();
            this.c2s_data.Add("Account", Account);
            base.MakeC2SData();
        }
 

        public override void OnRPCEvent(Dictionary<string, string> datas)
        {
            base.OnRPCEvent(datas);

            string err = datas["ErrorCord"];

            if (onS2CResult != null)
                onS2CResult("forget Passwork Result : " + err);
        }
    }
}
