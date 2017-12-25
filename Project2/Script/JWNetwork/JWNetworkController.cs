using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JWNetwork;
using UnityEngine.UI;

public class JWNetworkController : MonoBehaviour
{
    private AsynchronousClient loginServer = new AsynchronousClient();
    //private AsynchronousClient gameServer = new AsynchronousClient();

    /// <summary>
    /// 登入後取得大頭貼圖像資料,並予以變更新的大頭貼
    /// </summary>
    public Image avatar;

    /// <summary>
    /// 變更大頭貼的位元資料(於 Update() 中取得並使用,用完清空)
    /// </summary>
    private byte[] bsAvatarForChange = null;

    /// <summary>
    /// 網路通訊狀態
    /// </summary>
    public Text txt_status_value;


    /// <summary>
    /// 網路 登入Server IP / PORT
    /// </summary>
    public Text txt_LoginServer_IP;
    public Text txt_loginServer_Port;

    /// <summary>
    /// 網路 使用者 登入帳號及密碼
    /// </summary>
    public Text txt_Login_Account;
    public Text txt_Login_Password;



    /// <summary>
    /// 通訊處理類別 - 使用者帳號登入 
    /// </summary>
    private JWNetwork.Login login = new JWNetwork.Login();

    
    /// <summary>
    /// 通訊處理類別 - 註冊使用者帳號
    /// </summary>
    private Registered regist = new Registered();

    #region  因為不能跨執行緒變更UI , 所以採用變更變數值,UI執行緒判段值不為空時才更新UI內容
    /// <summary>
    /// 變更網路狀元資訊(用於 Update() 中取得並使用,用完清空)
    /// </summary>
    private string txtStatus = "";
    #endregion


    /// <summary>
    /// 初始化 , 指定封包格式 , 註冊 網路通訊處理類別(Login,Registed,....)
    /// </summary>
    private void init()
    {
        #region 1. 指定 封包樣式

        loginServer.packetType = PacketType.Len4BAndData;

        #endregion
        
        #region 2. 註冊 網路通訊處理類別
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
        // login 
        loginServer.RegRPCEvent(login, "C2S_Login", "S2C_Login");
        login.onLoginResult = s =>
        {
            //Debug.Log(s);
            txtStatus = "Login Result\n" + s;
        };
        login.onLoginAvartar = s =>
        {
            bsAvatarForChange = s;
        };

        // registed
        loginServer.RegRPCEvent(regist, "registered", "registered");
        regist.onS2CResult = s =>
        {
            Debug.Log(s);
            txtStatus = "registered Result\n" + s;
        };

        #endregion


        Debug.Log("Init JWNetwork ... OK");
    }

    // Use this for initialization
    void Start () {

        init();
		
	}
	
	/// <summary>
    /// 由於網路接收資料,跟Unity-Update()走的是不同執行緒
    /// 不能跨執行緒變更UI內容
    /// 因此需要把網路資料存出來
    /// 並在 Unity-Update()裡使用存出來的資料,並變更 UI 
    /// 在變更完 UI 後,下一個 frame 前將存出來資料清空
    /// </summary>
	void Update ()
    {
        // 因為不能跨執行緒變更UI , 所以採用變更變數值,UI執行緒判段值不為空時才更新UI內容
        if (txtStatus != "" && txt_status_value != null)
        {
            int maxLen = 200;
	        if (txtStatus.Length > maxLen)
	        {
	            txtStatus = txtStatus.Substring(0, maxLen);
	        }
            txt_status_value.text = txtStatus;
            txtStatus = "";

	    }

        // 使用者帳號登入時,取得大頭貼資料,設定新的大頭貼,並清空網路接收用的資料
        if(bsAvatarForChange!=null)
        {
            Texture2D t = new Texture2D(100, 100);
            t.LoadImage(bsAvatarForChange);
            avatar.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height), Vector2.zero);
            bsAvatarForChange = null;
        }

	}

    /// <summary>
    /// 連接 Login Server 
    /// </summary>
    public void ConnectLoginServer()
    {
        string ip = txt_LoginServer_IP == null ? "192.168.1.106" : txt_LoginServer_IP.text;
        int port = txt_loginServer_Port == null ? 8889 : int.Parse(txt_loginServer_Port.text);
        loginServer.Start(ip,port);
    }

    /// <summary>
    /// 關閉 Login Server
    /// </summary>
    public void StopLoginServer()
    {
        loginServer.Stop();
    }

    /// <summary>
    /// 使用者帳號登入
    /// </summary>
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


    public Text txt_regist_Name;
    public Text txt_regist_Password;
    public Text txt_regist_Email;

    /// <summary>
    /// 使用者註冊帳號
    /// </summary>
    public void Registed()
    {
        Hashtable data = new Hashtable();

        data.Add("firstName", "中文");
        data.Add("lastName", "ok123");
        data.Add("nickName", txt_regist_Name.text);
        data.Add("pwd", txt_regist_Password.text);
        data.Add("birthday", "2017-01-01");
        data.Add("email", txt_regist_Email.text);
        data.Add("gender", 1);
        data.Add("country", "158");
        data.Add("photo", 21845);

        regist.MakeC2SData(data);
        regist.ExecuteC2SEvent(true);
    }
}
