using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWNetwork
{
    public class GetAllUserPhoto : NetEventBase
    {
        public string photoId;
        public string photo;

        public override void MakeC2SData()
        {
            this.c2s_data = new Hashtable();
        }

        public override void OnRPCEvent(Hashtable datas)
        {
            int err = int.Parse(datas["rs"].ToString());

            switch (err)
            {
                case 0:
                    this.S2CResult("GetAllUserPhoto Success : total=" + datas["total"].ToString());
                    this.onS2CResultWithData("",datas);
                    break;
                case 1:
                    this.S2CResult("GetAllUserPhoto Fail !!!");
                    break;
                case 500:
                    this.S2CResult("GetAllUserPhoto  Fail : server error!!!");
                    break;
                default:
                    this.S2CResult("GetAllUserPhoto Fail : unknow error code (" + err.ToString() + ")");
                    break;

            }
        }
    }
}

