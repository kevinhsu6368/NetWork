using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 

namespace JWNetwork
{
    public class Logout : NetEventBase
    {

        public Logout()
        {

        }
 
 

        //public Action<string> onLogoutResult;


        #region 走預設 c2s 的處理流程 , 適合一個類別單一(C2S-S2C)功能
        public override void MakeC2SData()
        {
            // 指定 功能名稱
            //this.c2s_functionName = "C2S_Login";

            // 指定資料
            this.c2s_data = new Hashtable();
 
        }
        #endregion




        public override void OnRPCEvent(Hashtable datas)
        {
            try
            {
                if (datas == null)
                {
                    if (onS2CResult != null)
                        onS2CResult("Logout fail !!!");

                    Console.WriteLine("Logout fail !!! ");
                    return;
                }

                int err = int.Parse(datas["rs"].ToString());

                switch (err)
                {
                    case 0:
                        if (onS2CResult != null)
                            onS2CResult(string.Format("Logout Successed,uid={0}", datas["uid"].ToString()));
                        break;
                    case 500:
                        if (onS2CResult != null)
                            onS2CResult("Logout Fail : Server 錯誤 !!!");
                        break;
                    default:
                        break;
                }

 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\r\n" + e.StackTrace);
            }

        }
 

    }
}
