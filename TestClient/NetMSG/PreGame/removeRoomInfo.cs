using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class RemoveRoomInfo : NetEventBase
{
    public String roomId;//  遊戲室編號



    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();
        c2s_data.Add("roomId", roomId);
    }

    public override void OnRPCEvent(Hashtable datas)
    {

        int err = int.Parse((datas["rs"].ToString()));
        switch (err)
        {
            case 0:
                // S2CResult("ok");
                S2CResult("RemoveRoomInfo : OK");
                break;
            case 1:
                // S2CResult("ok");
                S2CResult("RemoveRoomInfo : No Match Room ID");
                break;

            default:
                S2CResult("RemoveRoomInfo : error code 無效");
                break;
        }
    }
}

