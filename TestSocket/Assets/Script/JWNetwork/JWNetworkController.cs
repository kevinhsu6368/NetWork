using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JWNetwork;
using UnityEngine.UI;

public class JWNetworkController : MonoBehaviour
{
    private AsynchronousClient loginServer = new AsynchronousClient();
    //private AsynchronousClient gameServer = new AsynchronousClient();


    public Text txt_status_value;

    public Text txt_LoginServer_IP;
    public Text txt_loginServer_Port;


    public Text txt_Login_Account;
    public Text txt_Login_Password;



    private Login login = new Login();

    // 因為不能跨執行緒變更UI , 所以採用變更變數值,UI執行緒判段值不為空時才更新UI內容
    private string txtStatus = "";

    private void init()
    {
        // setup login server connect event
        loginServer.onConnected = () =>
        {
            Debug.Log("Connected Login Server OK");
            txtStatus = "Connected OK (Login Server)";
        };
        loginServer.onDisconnected = s =>
        {
            Debug.Log("Disconnected Login Server");
            txtStatus = "Disconnected (Login Server)";
        };

        // setup net event of login server
        loginServer.RegRPCEvent(login, "C2S_Login", "S2C_Login");
        login.onLoginResult += s =>
        {
            Debug.Log(s);
            txtStatus = "Login Result\n" + s;
        };

        //
        Debug.Log("Init JWNetwork ... OK");
    }

    // Use this for initialization
    void Start () {

        init();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // 因為不能跨執行緒變更UI , 所以採用變更變數值,UI執行緒判段值不為空時才更新UI內容
        if (txtStatus != "" && txt_status_value != null)
	    {
	        txt_status_value.text = txtStatus;
            txtStatus = "";

	    }

	}

    public void ConnectLoginServer()
    {
        string ip = txt_LoginServer_IP == null ? "192.168.1.106" : txt_LoginServer_IP.text;
        int port = txt_loginServer_Port == null ? 8889 : int.Parse(txt_loginServer_Port.text);
        loginServer.Start(ip,port);
    }

    public void StopLoginServer()
    {
        loginServer.Stop();
    }

    public void Login()
    {
        //Debug.Log("Login .. start");
        // 設定登入資料
        login.Account = "kevin";
        login.Password = "123";

        if (txt_Login_Account != null)
            login.Account = txt_Login_Account.text;

        if (txt_Login_Password != null)
            login.Password = txt_Login_Password.text;

        // 將資料打包
        login.MakeC2SData();

        // 發送封包
        login.ExecuteC2SEvent(true);
        //Debug.Log("Login .. end");
    }
}
