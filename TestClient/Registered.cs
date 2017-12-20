using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class Registered : NetEventBase
{
    public override void MakeC2SData()
    {

        c2s_data = new Hashtable();
        c2s_data.Add("firstName", "中文");
        c2s_data.Add("lastName", "ok123");
        c2s_data.Add("nickName", "中文ABC1923");
        c2s_data.Add("pwd", "thisIsPassword");
        c2s_data.Add("birthday", "2017-01-01");
        c2s_data.Add("email", "vvvv12345@gmail.com");
        c2s_data.Add("gender", 1);
        c2s_data.Add("country", "158");
        c2s_data.Add("photo", 21845);

    }

    public override void OnRPCEvent(Hashtable datas)
    {
        string err = datas["rs"].ToString();
        switch (err)
        {
            case "0":
            {
                
            }
                break;
            case "1":
            {
                
            }
                break;
            case "2":
            {
                
            }
                break;
            default:
                break;
        }
    }
}

