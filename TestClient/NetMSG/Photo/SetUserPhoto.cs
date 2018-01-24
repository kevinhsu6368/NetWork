using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWNetwork
{
    public class SetUserPhoto : NetEventBase
    {
        public long photoId;

        public override void MakeC2SData()
        {
            this.c2s_data = new Hashtable();
            this.c2s_data.Add("photoId", photoId);
        }

        public override void OnRPCEvent(Hashtable datas)
        {
            int err = int.Parse(datas["rs"].ToString());

            switch (err)
            {
                case 0:
                    this.S2CResult("SetUserPhoto Success : uid =" + datas["uid"].ToString() + "photoID = " + datas["photo"].ToString());
                    break;
                case 1:
                    this.S2CResult("SetUserPhoto Fail !!!");
                    break;
                case 500:
                    this.S2CResult("SetUserPhoto  Fail : server error!!!");
                    break;
                default:
                    this.S2CResult("SetUserPhoto Fail : unknow error code (" + err.ToString() + ")");
                    break;

            }
        }
    }
}
