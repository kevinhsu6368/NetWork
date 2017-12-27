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
    public string birthday = "2017-01-01";
    public string email;
    public int gender = 1;
    public string country;
    public string photo;

    public override void MakeC2SData()
    {

        c2s_data = new Hashtable();
        c2s_data.Add("firstName", firstName);
        c2s_data.Add("lastName", lastName);
        c2s_data.Add("nickName", nickName);
        c2s_data.Add("pwd", pwd);
        c2s_data.Add("birthday", birthday);
        c2s_data.Add("email", email);
        c2s_data.Add("gender", gender);
        c2s_data.Add("country", country);
        c2s_data.Add("photo", "");// photo);

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

