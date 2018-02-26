using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class CreateRoomInfo : NetEventBase
{
 
    public int roomType;//	1=01game,2=cricket,3=count up,4=bull hunter,5=match
    public int playerAmount;//    遊戲人數 1,2,3,4
    public int select;//  依據roomType會有各種不同的對應,EX.01game就是選擇1=301.2=501.3=701...依此類推
    public int gameType;//	0=SDB,1=Online



    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();
        c2s_data.Add("roomType", roomType);
        c2s_data.Add("playerAmount", playerAmount);
        c2s_data.Add("select", select);
        c2s_data.Add("gameType", gameType);
    }

    public override void OnRPCEvent(Hashtable datas)
    {

        int err = int.Parse((datas["rs"].ToString()));
        switch (err)
        {
            case 0:
               // S2CResult("ok");
                onS2CResultWithData("CreateRoomInfo OK", datas);
                break;

            default:
                S2CResult("CreateRoomInfo : error code 無效");
                break;
        }
    }
}

