using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

//using System.Threading.Tasks;

namespace JWNetwork
{

    public enum PacketControl
    {
        NONE = 0,
        DES_ECB = 1,
        DES2_ECB = 2,
        DES3_ECB = 3,
        DES_CBC = 4,
        DES2_CBC = 5,
        DES3_CBC = 6
    }

    /// <summary>
    /// 封包樣式
    /// </summary>
    public enum PacketType
    {
        /// <summary>
        /// 封包有 Header 及 Data
        /// </summary>
        HeaderAndData,

        /// <summary>
        /// 封包只有 Data 的部份
        /// Send 
        /// </summary>
        Data,
        /// <summary>
        /// 封包為 封包長度(4bytes) + 資料
        /// </summary>
        Len4BAndData
    }

    public class Packet
    {


        public Packet()
        {

        }

        #region Header

        public UInt32 packetLen;

        /// <summary>
        /// 封包資料格式
        ///     0x00: raw bytes data
        ///     0x01: utf8-json
        ///     0x02: utf8-xml
        /// </summary>
        public byte dataType;

        /// <summary>
        /// 加密控制碼
        /// Low byte:
        ///     0:不加密
        ///     1:DES-ECB
        ///     2:2DES-ECB
        ///     3:3DES-ECB
        ///     4:DES-CBC
        ///     5:2DES-CBC 
        ///     6:3DES-CBC
        /// High byte: key index
        ///     1 ~ F
        /// </summary>
        public byte dataControl = 0x00; // 8 個 byte ,保留字元
        #endregion

        #region Data

        // raw data
        public byte[] bsData;

        #endregion

        private void Update()
        {
            this.packetLen = (UInt16)(4 + 1 + 1 + this.bsData.Length);
        }

        public Packet(UInt16 msgID, byte[] datas)
        {
            this.dataType = 0x00;
            this.dataControl = 0x00;

            this.bsData = new byte[2 + datas.Length];
            byte[] bsMsgID = BitConverter.GetBytes(msgID);
            Array.Copy(bsMsgID, 0, bsData, 0, 2);
            Array.Copy(datas, 0, bsData, 2, datas.Length);
            Update();
        }

        public Packet(UInt16 msgID, byte[] datas, byte control)
        {
            this.dataType = 0x00;
            this.dataControl = control;

            this.bsData = new byte[2 + datas.Length];
            byte[] bsMsgID = BitConverter.GetBytes(msgID);
            Array.Copy(bsMsgID, 0, bsData, 0, 2);
            Array.Copy(datas, 0, bsData, 2, datas.Length);
            Update();
        }

        public Packet(UInt16 msgID, byte[] datas, PacketControl control, uint keyIndex)
        {
            this.dataType = 0x00;

            if (keyIndex > 0x0F)
                keyIndex = 1; // 無效 key index , 改使用預設第一把 key


            this.dataControl = (byte)((keyIndex << 4) + (int)control);

            this.bsData = new byte[2 + datas.Length];
            byte[] bsMsgID = BitConverter.GetBytes(msgID);
            Array.Copy(bsMsgID, 0, bsData, 0, 2);
            Array.Copy(datas, 0, bsData, 2, datas.Length);
            Update();
        }

        public Packet(string functionName, Hashtable datas)
        {
            // {
            //   "function":"Login" , 
            //   "Data": 
            //   [
            //     "Name":"Kevin",
            //     "Pwd":"12345"
            //   ]
            // 
            // }

            /*
            封包格式範例:

            {
                "methodName": "方法名稱",
  "paramObject": {
                    //JSON塞這裡面	
                }
            }
            */

            this.dataType = 0x01;
            this.dataControl = 0x00;


            string jsonStart = "{\r\n" +
                               "  \"methodName\":\"" + functionName + "\",\r\n" +
                               "  \"paramObject\" : {"  + "\r\n";

            string jsonData = "";

            jsonData = MiniJSON.jsonEncode(datas);

            //int index = 1;
            //foreach (var v in datas)
            //{
            //    string next = (index == datas.Count && datas.Count != 1) ? "\r\n" : ",\r\n";

            //    jsonData += string.Format("  \"{0}\":\"{1}\"{2}", v.Key, v.Value, next);

            //    index++;
            //}

            string jsonEnd = "}";

            string str = jsonStart + jsonData + jsonEnd;
            byte[] bsJsonData = Encoding.UTF8.GetBytes(str);

            this.bsData = new byte[bsJsonData.Length];

            Array.Copy(bsJsonData, 0, this.bsData, 0, bsJsonData.Length);

            Update();
        }


        public Packet(string functionName, Hashtable datas, byte control)
        {
            // {
            //   "function":"Login" , 
            //   "Data": 
            //   [
            //     "Name":"Kevin",
            //     "Pwd":"12345"
            //   ]
            // 
            // }

            this.dataType = 0x01;
            this.dataControl = control;


            string jsonStart = "{\r\n" +
                                "  \"methodName\":\"" + functionName + "\",\r\n" +
                                "  \"paramObject\" : " + "\r\n";

            string jsonData = "";

            jsonData = "  "  + MiniJSON.jsonEncode(datas);

            //int index = 1;
            //foreach (var v in datas)
            //{
            //    string next = (index == datas.Count && datas.Count != 1) ? "\r\n" : ",\r\n";


            //        jsonData += string.Format("  \"{0}\":\"{1}\"{2}", v.Key, v.Value, next);

            //    index++;
            //}

            string jsonEnd = "\r\n}";




            string str = jsonStart + jsonData + jsonEnd;

            Hashtable _ht = new Hashtable();
            _ht.Add("methodName", functionName);
            _ht.Add("paramObject", datas);
            string _json = MiniJSON.jsonEncode(_ht);

            str = "";
            byte[] bsJsonData = Encoding.UTF8.GetBytes(_json);

            this.bsData = new byte[bsJsonData.Length];
            
            Array.Copy(bsJsonData, 0, this.bsData, 0, bsJsonData.Length);

            Update();


        }


        public byte[] FullData
        {
            get
            {
                byte[] bs = new byte[/*header*/ 4 + 1 + 1 + /*data*/ bsData.Length];

                byte[] bLen = BitConverter.GetBytes(this.packetLen);
                Array.Copy(bLen, 0, bs, 0, bLen.Length);

                bs[4] = dataType;
                bs[5] = dataControl;

                Array.Copy(bsData, 0, bs, 6, bsData.Length);

                return bs;
            }

        }

        public byte[] Len4BData
        {
            get
            {
                byte[] bs = new byte[/*len*/ 4 +  /*data*/ bsData.Length];
                int arrayLength = System.Net.IPAddress.HostToNetworkOrder(bsData.Length);
                byte[] bLen = BitConverter.GetBytes(arrayLength);
                Array.Copy(bLen, 0, bs, 0, bLen.Length);
                Array.Copy(bsData, 0, bs, 4, bsData.Length);

                return bs;
            }
        }


    }


    public class NetEvent
    {
        public NetEvent()
        {

        }

        /// <summary>
        /// 收到封包並解析資料,並觸發已註冊的處理事件
        /// </summary>
        /// <param name="msgID">註冊的功能識別碼</param>
        /// <param name="datas">資料</param>
        public delegate void OnRawEvent(UInt16 msgID, byte[] datas);

        /// <summary>
        /// 收到封包並解析資料,並觸發已註冊的處理事件
        /// </summary>
        /// <param name="functionName">註冊的功能名稱</param>
        /// <param name="datas">資料</param>
        public delegate void OnRPCEvent(string functionName, Hashtable datas);

        /// <summary>
        /// 連線成功的事件
        /// </summary>
        public delegate void OnConnected();

        /// <summary>
        /// 連線失敗的事件
        /// </summary>
        /// <param name="errMsg"></param>
        public delegate void OnConnectError(string errMsg);

        /// <summary>
        /// 連線逾時的事件
        /// </summary>
        public delegate void OnConnecteTimeout();

        /// <summary>
        /// 斷線的事件
        /// </summary>
        /// <param name="flag">斷線額外資訊</param>
        public delegate void OnDisconnected(string flag);

        /// <summary>
        /// 接收封包的事件
        /// </summary>
        public delegate void OnRecv();

        /// <summary>
        /// 發送封包成功的事件
        /// </summary>
        public delegate void OnSend();

    }

    /// <summary>
    /// 網路功能事件的基礎煩別
    /// </summary>
    public class NetEventBase 
    {
        public NetEventBase()
        {
            this.onRawEvent = this.OnRawEvent;
            this.onRpcEvent = this.OnRPCEvent;
        }

        /// <summary>
        /// Client連線處理類(非同步機制)
        /// </summary>
        public AsynchronousClient client;


        /// <summary>
        /// 網路通訊 S2C 過程,收到封包並觸發指定的處理事件(MSGID)
        /// </summary>
        public NetEvent.OnRawEvent onRawEvent;


        /// <summary>
        /// 網路通訊 S2C 過程,收到封包並觸發指定的處理事件(RPC)
        /// </summary>
        public NetEvent.OnRPCEvent onRpcEvent;


        /// <summary>
        /// 網路通訊 S2C 過程,處理結果通知事件
        /// </summary>
        public Action<string> onS2CResult;


        /// <summary>
        /// 網路通訊 S2C 過程,處理結果通知事件(附帶原始料)
        /// </summary>
        public Action<string, Hashtable> onS2CResultWithData;



        #region C2S 

        public string c2s_functionName;
        
        public Hashtable c2s_data = new Hashtable();

        #endregion


        #region S2C

        public string s2c_functionName;


        public virtual void OnRPCEvent(Hashtable datas)
        {

        }

        public void S2CResult(string msg)
        {
            if (this.onS2CResult != null)
                this.onS2CResult(msg);
        }

        #endregion


        /// <summary>
        /// 收到封包並解析資料,並觸發已註冊的處理事件
        /// 1.如果 
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="datas"></param>
        public virtual void OnRPCEvent(string functionName, Hashtable datas)
        {
            Console.WriteLine("OnRPCEvent : " + functionName + " at : " + DateTime.Now.ToString("HH:mm:ss.fff"));
            if (!string.IsNullOrEmpty(this.s2c_functionName) && this.s2c_functionName.Equals(functionName))
            {
                OnRPCEvent(datas);
            }
            else
            {
                
            }

        }


        public virtual void OnRawEvent(ushort msgID, byte[] datas)
        {
            
        }


        /// <summary>
        /// 準備 Client 2 Server 的資料,
        /// 需要指定下列內容
        /// c2s_functionName : 要執行的功能名稱 
        /// c2s_data : 要帶的資料
        /// </summary>
        public virtual void MakeC2SData()
        {
            
        }

        public void MakeC2SData(Hashtable data)
        {
            this.c2s_data = data;
        }

        /// <summary>
        /// 執行 Client 2 Server 的事件
        /// (必需先呼叫 MakeC2SData , 指定好遠方的功能及參數資料)
        /// </summary>
        /// <param name="bDefault"></param>
        public virtual void ExecuteC2SEvent(bool bDefault)
        {
            if (bDefault && !string.IsNullOrEmpty(this.c2s_functionName))
            {
                Send(this.c2s_functionName, this.c2s_data);
            }

        }

        public void AttachClient(AsynchronousClient client)
        {
            this.client = client;
        }

        public void Send(UInt16 msgID,byte[] datas)
        {
            if(client==null)
                return;

            client.SendPacket(msgID,datas);
        }

        /// <summary>
        /// 發送命令資料 , 執行遠方功能
        /// </summary>
        /// <param name="functionName">功能名稱</param>
        /// <param name="data">資料</param>
        public void Send(string functionName, Hashtable data)
        {
            if (client == null)
                return;

           client.SendRPC(functionName,data);

        }



    }

}
