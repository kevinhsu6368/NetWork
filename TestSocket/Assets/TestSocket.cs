using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestSocket : MonoBehaviour {

    AsynchronousClient client;

    public GameObject IP;
    public GameObject Port;
    public GameObject RecvData;

    private string txtRecvText = "";
    private bool bRecvFlag = false;

	// Use this for initialization
	void Start () {
        
        client = new AsynchronousClient();
        client.onRecvEvent += OnRecvData;
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (bRecvFlag)
        {
            Text txt = RecvData.GetComponent<Text>();
            txt.text = txtRecvText;
            txtRecvText = "";
            bRecvFlag = false;
        }
	}

    public void OnStart()
    {
        Text tIP = IP.GetComponent<Text>();
        string ip = tIP.text;

        Text tPort = Port.GetComponent<Text>();
        int port = int.Parse(tPort.text);
        client.Start(ip, port);
    }

    public void OnSendMsg()
    {
        client.Send("這是來自unity的測試哦!");
    }

    public void OnSendHex()
    {
        byte[] bs = new byte[] { 0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0a,0xF1,0xF2};
        client.Send(bs);
    }

    private void OnRecvData(byte [] recvData)
    {
       
        txtRecvText = StringTools.Bin2Hex(recvData);
        bRecvFlag = true;
    }

    public void OnClose()
    {
        client.Close();
    }

}
