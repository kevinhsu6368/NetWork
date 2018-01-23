using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;

public class AddPartnerRequest : NetEventBase
{
    public override void MakeC2SData()
    {
        base.MakeC2SData();
    }

    public override void OnRPCEvent(Hashtable datas)
    {
        // no rs
        int inviter = int.Parse((datas["inviter"].ToString()));

        string nickName = datas["nickName"].ToString();

        S2CResult(string.Format("AddPartnerRequest from {0} ({1}) , yes or no ?",inviter,nickName));
        onS2CResultWithData("", datas);
    }
}
 
