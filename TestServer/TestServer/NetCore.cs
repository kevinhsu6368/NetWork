using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

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
        Data , 
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


        public Packet(string functionName, Dictionary<string, string> datas, byte control)
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
                               "  \"Function\":\"" + functionName + "\",\r\n";

            string jsonData = "";
            int index = 1;
            foreach (var v in datas)
            {
                string next = (index == datas.Count && datas.Count != 1) ? "\r\n" : ",\r\n";


                jsonData += string.Format("  \"{0}\":\"{1}\"{2}", v.Key, v.Value, next);

                index++;
            }

            string jsonEnd = "}";

            string str = jsonStart + jsonData + jsonEnd;
            byte[] bsJsonData = Encoding.UTF8.GetBytes(str);

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

                byte[] bLen = BitConverter.GetBytes(this.packetLen);
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

        public delegate void OnRawEvent(AsynchronousServer.Client client, UInt16 msgID, byte[] datas);

        public delegate void OnRPCEvent(AsynchronousServer.Client client,string functionName, Dictionary<string, string> datas);
        

        public delegate void OnConnected();

        public delegate void OnConnecteTimeout();

        public delegate void OnDisconnected(string flag);

        public delegate void OnRecv();

        public delegate void OnSend();

        public delegate void OnAcceptClient(Object client);

        public delegate void OnKillClient(Object client);

    }


    public class NetEventBase //: IRPCEvent, IRawEvent
    {
        public NetEventBase()
        {
            onRawEvent = OnRawEvent;
            onRpcEvent = onRpcEvent;
        }

        public AsynchronousServer server;
        public AsynchronousServer.Client client;
        public NetEvent.OnRawEvent onRawEvent;
        public NetEvent.OnRPCEvent onRpcEvent;

        public virtual void OnRPCEvent(AsynchronousServer.Client client, string functionName, Dictionary<string, string> datas)
        {
            
        }


        public virtual void OnRawEvent(AsynchronousServer.Client client, ushort msgID, byte[] datas)
        {
            
        }

        public void AttachClient(AsynchronousServer server,AsynchronousServer.Client client)
        {
            this.server = server;
            this.client = client;
            //this.client = client;
        }

        public void Send(UInt16 msgID,byte[] datas)
        {
            if (server == null)
                return;

            server.Send(this.client, datas);
        }


        public void Send(AsynchronousServer.Client client , string functionName, Dictionary<string, string> data)
        {
            if (server == null)
                return;

            server.SendRPC(client,functionName, data);

        }

        


    }

}
