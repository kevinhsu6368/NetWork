using System;
using System.Collections;
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
            this.c2s_data = new Hashtable();
            this.c2s_data.Add("Account", Account);
            base.MakeC2SData();
        }
 

        public override void OnRPCEvent(Hashtable datas)
        {
            base.OnRPCEvent(datas);

            string err = datas["ErrorCord"].ToString();

            if (onS2CResult != null)
                onS2CResult("forget Passwork Result : " + err);
        }
    }
}
