using System;
using System.Collections.Generic;
using System.Linq;
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


    }


    public class NetEvent
    {
        public NetEvent()
        {

        }

        public delegate void OnRawEvent(UInt16 msgID, byte[] datas);

        public delegate void OnRPCEvent(string functionName, Dictionary<string, string> datas);

        public delegate void OnConnected();

        public delegate void OnConnecteTimeout();

        public delegate void OnDisconnected(string flag);

        public delegate void OnRecv();

        public delegate void OnSend();

    }


    public class NetEventBase //: IRPCEvent, IRawEvent
    {
        public NetEventBase()
        {
            onRawEvent = OnRawEvent;
            onRpcEvent = onRpcEvent;
        }

        public AsynchronousClient client;
        public NetEvent.OnRawEvent onRawEvent;
        public NetEvent.OnRPCEvent onRpcEvent;

        public virtual void OnRPCEvent(string functionName, Dictionary<string, string> datas)
        {
            
        }


        public virtual void OnRawEvent(ushort msgID, byte[] datas)
        {
            
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

        public void Send(string functionName, Dictionary<string,string> data)
        {
            if (client == null)
                return;

            
        }



    }

}
