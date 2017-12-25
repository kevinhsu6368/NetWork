using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWNetwork;


public class Registered : NetEventBase
{
    public string firstName;
    public string lastName;
    public string nickName;
    public string pwd;
    public string birthday;
    public string email;
    public string gender;
    public string country;
    public string photo;

    public override void MakeC2SData()
    {

        c2s_data = new Hashtable();
        c2s_data.Add("firstName", "中文");
        c2s_data.Add("lastName", "ok123");
        c2s_data.Add("nickName", nickName);
        c2s_data.Add("pwd", pwd);
        c2s_data.Add("birthday", "2017-01-01");
        c2s_data.Add("email", email);
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
                    S2CResult("Registed : Success");
                }
                break;
            case "1":
                {
                    S2CResult("Registed : email重複");
                }
                break;
            case "2":
                {
                    S2CResult("Registed : 暱稱重複");
                }
                break;

            default:
                S2CResult("Registed : error code 無效");
                break;
        }
    }
}

