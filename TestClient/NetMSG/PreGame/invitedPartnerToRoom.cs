using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class InvitedPartnerToRoom : NetEventBase
{
    public long partnerUid;//  夥伴uid
    public String roomId;// 房間編號



    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();
        c2s_data.Add("partnerUid", partnerUid);
        c2s_data.Add("roomId", roomId);
    }

    public override void OnRPCEvent(Hashtable datas)
    {

        int err = int.Parse((datas["rs"].ToString()));
        switch (err)
        {
            case 0:
                // S2CResult("ok");
                S2CResult("InvitedPartnerToRoom : OK");
                break;
            case 1:
                // S2CResult("ok");
                S2CResult("InvitedPartnerToRoom : 1=無此夥伴資訊");
                break;
            case 2:
                // S2CResult("ok");
                S2CResult("InvitedPartnerToRoom : 2=夥伴目前無法接受邀請");
                break;

            default:
                S2CResult("InvitedPartnerToRoom : error code 無效");
                break;
        }
    }
}


