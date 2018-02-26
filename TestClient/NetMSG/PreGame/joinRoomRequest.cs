using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JWNetwork;


public class JoinRoomRequest : NetEventBase
{
    public long partnerUid;//  夥伴uid
    public String roomId;// 房間編號



    public override void MakeC2SData()
    {
        c2s_data = new Hashtable();

    }

    public override void OnRPCEvent(Hashtable datas)
    {
        /*
        long inviter 邀請人uid
String  nickName 邀請人暱稱
int roomType    1 = 01game,2 = cricket,3 = count up,4 = bull hunter,5 = match
int select  依據roomType會有各種不同的對應,EX.01game就是選擇1 = 301.2 = 501.3 = 701...依此類推
int playAmount  遊戲人數 1,2,3,4
int gameType    0 = SDB,1 = Online
            */
        long inviter = long.Parse(datas["inviter"].ToString());
        string nickName = datas["nickName"].ToString();
        long roomType = long.Parse(datas["roomType"].ToString());
        long select = long.Parse(datas["select"].ToString());
        long playAmount = long.Parse(datas["playAmount"].ToString());
        long gameType = long.Parse(datas["gameType"].ToString());
        string roomId = datas["roomId"].ToString();
        string[] roomTypeNames = { "Zero One", "cricket", "count up", "bull hunter", "match", "Practice", "Party" };
        string roomInfo = roomTypeNames[roomType - 1];


        // 詢問是否接受邀請加入遊戲局裡
        string msg = string.Format("Do you want to agree that join to the {0} game of {1} ?", roomInfo, nickName);
        //S2CResult(msg);
        onS2CResultWithData(msg, datas);
    }
}


