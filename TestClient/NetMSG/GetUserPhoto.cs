using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWNetwork
{
    public class GetUserPhoto : NetEventBase
    {
        /// <summary>
        /// 相片編號
        /// </summary>
        public int photoId = 0;

        public override void MakeC2SData()
        {
            this.c2s_data = new Hashtable();
            this.c2s_data.Add("photoId", photoId);
        }

        public override void OnRPCEvent(Hashtable datas)
        {
            try
            {
                //0 = 正常,1 = 無此照片資料
                int err = int.Parse(datas["rs"].ToString());
                switch (err)
                {
                    case 0:
                        this.S2CResult("GetUserPhoto Success, photoId=" + int.Parse(datas["photoId"].ToString()) + ",uid=" + int.Parse(datas["uid"].ToString())  +
                                        ",photo=" + datas["photo"]);
                        break;
                    case 1:
                        this.S2CResult("GetUserPhoto Fail : 無此照片資料");
                        break;
                    case 500:
                        this.S2CResult("GetUserPhoto Fail : Server error");
                        break;
                    default:
                        this.S2CResult("GetUserPhoto Fail : unknow error code (" + err.ToString() + ")");
                        break;
                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
