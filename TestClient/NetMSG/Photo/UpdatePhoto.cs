using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWNetwork
{
    public class UpdatePhoto : NetEventBase
    {
        public string photoId;
        public string photo;

        public override void MakeC2SData()
        {
            this.c2s_data = new Hashtable();
            this.c2s_data.Add("photoId", photoId);
            this.c2s_data.Add("photo", photo);
        }

        public override void OnRPCEvent(Hashtable datas)
        {
            int err = int.Parse(datas["rs"].ToString());

            switch (err)
            {
                case 0:
                    this.S2CResult("updatePhoto Success : PhotoID=" + datas["photoId"].ToString());
                    break;
                case 1:
                    this.S2CResult("updatePhoto Fail !!!");
                    break;
                case 500:
                    this.S2CResult("updatePhoto  Fail : server error!!!");
                    break;
                default:
                    this.S2CResult("UploupdatePhoto Fail : unknow error code (" + err.ToString() + ")");
                    break;

            }
        }
    }
}

