using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class AddPartnerResponse : NetEventBase
{
    public bool isAgree = false;
    public string inviterUid = "";

    public override void MakeC2SData()
    {

        c2s_data = new Hashtable();
        c2s_data.Add("flag", isAgree ? 0 : 1); // 0:同意,1:不同意
        c2s_data.Add("inviterUid", inviterUid); // 0:同意,1:不同意
    }

    public override void OnRPCEvent(Hashtable datas)
    {
        int err = int.Parse((datas["rs"].ToString()));
        switch (err)
        {
            case 0:
                S2CResult("AddPartnerResponse : Success");
                break;
            case 1:
                S2CResult("AddPartnerResponse : 不同意(只有邀請人會收到)");
                break;
 
            default:
                S2CResult("AddPartnerResponse : error code 無效");
                break;
        }
    }
}
