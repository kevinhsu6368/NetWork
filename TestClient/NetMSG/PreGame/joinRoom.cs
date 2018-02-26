using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JWNetwork;


public class JoinRoom : NetEventBase
{
    public int flag;//	0:同意,1:不同意
    public long inviterUid;//  邀請人uid
    public string roomId;// 遊戲室編號


    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();
        c2s_data.Add("flag", flag);
        c2s_data.Add("inviterUid", inviterUid);
        c2s_data.Add("roomId", roomId);

    }

    public override void OnRPCEvent(Hashtable datas)
    {
 
        // 詢問是否接受邀請加入遊戲局裡
         
        S2CResult("JoinRoom ... S2C ... OK");
    }
}


