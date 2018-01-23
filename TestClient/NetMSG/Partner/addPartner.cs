using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class AddPartner : NetEventBase
{
    public string email;

    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();
        c2s_data.Add("email", email);
    }

    public override void OnRPCEvent(Hashtable datas)
    {
        int err = int.Parse((datas["rs"].ToString()));
        switch (err)
        {
            case 0:
                S2CResult("ok");
                break;
            case 1:
                S2CResult("查無夥伴資訊");
                break;
            case 2:
                S2CResult("夥伴未上線");
                break;
            case 3:
                S2CResult("已經加為夥伴");
                break;
            default:
                S2CResult("Registed : error code 無效");
                break;
        }
    }
}
