﻿
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;
//using System.Security.Policy;
//using System.Windows.Forms.Layout;
using LitJson;


namespace JWNetwork
{

// State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;

        // Size of receive buffer.  
        public const int BufferSize = 1024 * 1024;

        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];

        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    

    public class AsynchronousClient
    {
        // The port number for the remote device.  
        private const int port = 11000;

        private const int TIMEOUT = 1000*10;

        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);

        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);

        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.  
        private String response = String.Empty;
        private Socket client = null;

        /// <summary>
        /// 封包樣式
        /// </summary>
        public PacketType packetType = PacketType.Data;

        Queue<byte[]> lsRecvBytes = new Queue<byte[]>();

        private Thread t_ProcRecv;

        private bool isRunning = false;

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private static void DoProcRecv(object obj)
        {
            AsynchronousClient client = (AsynchronousClient)obj;
            while (client != null && client.isRunning)
            {
                Thread.Sleep(10);
                if (client.lsRecvBytes.Count == 0)
                    continue;

                try
                {
                    byte [] p = client.lsRecvBytes.Dequeue();

                    #region 沒有封包頭的封包格式 json-utf8
                    if (client.packetType == PacketType.Data)  
                    {
                        string json = Encoding.UTF8.GetString(p);
                        int maxLen = 200;
                        if (json.Length > maxLen)
                        {
                            Console.WriteLine(json.Substring(0, maxLen) + " ... ");
                        }
                        else
                        {
                            Console.WriteLine(json);
                        }
                        

                        // parser json 
                        JsonData jObj = JsonMapper.ToObject(json);
                        

                        string[] lsLines = json.Replace("\r\n", "\n").Split('\n');
                        string function = jObj["Function"].ToString();
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, JsonData> v in jObj)
                        {
                            if(v.Key == "Function")
                                continue;

                            string key = v.Key;
                            string value = v.Value.IsString ? v.Value.ToString() : ""; // 先轉一層
                            data.Add(key, value);
                        }


                        NetEvent.OnRPCEvent callBack = client.lsRPCEvent[function];

                        if (callBack != null)
                            callBack(function, data);



                    }
                    #endregion

                    #region 有封包頭的封包格式
                    else if (client.packetType == PacketType.HeaderAndData) 
                    {

                    }
                    #endregion

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// 啟動網路連線服務
        /// </summary>
        /// <param name="ip">IP 位址</param>
        /// <param name="port">通訊埠</param>
        public void Start(String ip, int port)
        {
            // Connect to a remote device.  
            try
            {
                if (client != null && client.Connected)
                    return;

                

                // Establish the remote endpoint for the socket.  
                // The name of the   
                // remote device is "host.contoso.com".  
                //IPHostEntry ipHostInfo = Dns.Resolve("localhost");
                //ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);

                //if (connectDone.WaitOne(TIMEOUT))
                //{
                    //if (this.onConnecteTimeout != null)
                    //    this.onConnecteTimeout();
                //}

                /*
            // Send test data to the remote device.  
            Send(client, "hello kevin !<EOF>");
            sendDone.WaitOne();


            // Send test data to the remote device.  
            Send(client, "This is a test<EOF>");
            sendDone.WaitOne();


            // Receive the response from the remote device.  
            Receive(client);
            receiveDone.WaitOne();

            // Write the response to the console.  
            Console.WriteLine("Response received : {0}", response);

            // Release the socket.  
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            */

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public Dictionary<UInt16, NetEvent.OnRawEvent> lsRawEvent = new Dictionary<UInt16, NetEvent.OnRawEvent>();

        public Dictionary<string, NetEvent.OnRPCEvent> lsRPCEvent = new Dictionary<string, NetEvent.OnRPCEvent>();

        public NetEvent.OnConnected onConnected = null;

        public NetEvent.OnDisconnected onDisconnected = null;

        public NetEvent.OnConnecteTimeout onConnecteTimeout = null;

        public bool RegRawEvent(NetEventBase target, UInt16 msgID, NetEvent.OnRawEvent callFunc)
        {
            try
            {
                target.client = this;
                lsRawEvent.Add(msgID, callFunc);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool RegRPCEvent(NetEventBase target, string funcName, NetEvent.OnRPCEvent callFunc)
        {
            try
            {
                target.client = this;
                lsRPCEvent.Add(funcName , callFunc);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool RegRPCEvent(NetEventBase target, string c2s_funcName,string s2c_funcName)
        {
            try
            {
                target.client = this;
                target.c2s_functionName = c2s_funcName;
                target.s2c_functionName = s2c_funcName;
                lsRPCEvent.Add(s2c_funcName, target.onRpcEvent);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        public void SendPacket(Packet p)
        {
            if (this.packetType == PacketType.Data)
            {
                Send(p.bsData);
            }
            else if (this.packetType == PacketType.HeaderAndData)
            {
                Send(p.FullData);
            }
            
        }

        /// <summary>
        /// 發送不帶封包頭的純文字封包
        /// </summary>
        /// <param name="msg"></param>
        public void SendString(string msg)
        {
            byte[] bsData = Encoding.UTF8.GetBytes(msg);
            Send(bsData);
        }




        /// <summary>
        /// 發送 RPC - JSON(utf8) 字串封包
        /// </summary>
        /// <param name="function">功能名稱</param>
        /// <param name="data">資料</param>
        public void SendRPC(string function, Dictionary<string, string> data)
        {
            //Dictionary<string,string > loginData = new Dictionary<string, string>();
            //loginData.Add("Name","Kevin");
            //loginData.Add("Pwd", "12345");
            //SendRPC("Login", loginData);

            
            Packet p = new Packet(function,data,0x00);
            SendPacket(p);

        }

        /// <summary>
        /// 發送 RPC - Byte Array 資料
        /// </summary>
        /// <param name="msgID"></param>
        /// <param name="datas"></param>
        public void SendPacket(UInt16 msgID, byte[] datas)
        {
            Packet p = new Packet(msgID,datas);
            SendPacket(p);
        }

        public void SendPacket(UInt16 msgID , byte [] datas , PacketControl control , UInt16 keyIndex)
        {
            Packet p = new Packet(msgID, datas , control, keyIndex);
            SendPacket(p);
        }



        /// <summary>
        /// 結束網路線服務
        /// </summary>
        public void Stop()
        {
            try
            {
 
                    this.client.Shutdown(SocketShutdown.Both);
                    this.client.Close();
                    //this.client.Dispose();
                    this.client = null;
                    if (this.onDisconnected != null)
                        this.onDisconnected("Success");
                    this.isRunning = false;

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\r\n" + e.StackTrace);
            }

        }


        private void StartProcRecvThread()
        {
            this.isRunning = true;
            t_ProcRecv = new Thread(new ParameterizedThreadStart(DoProcRecv));
            t_ProcRecv.Start(this);
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket) ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                StartProcRecvThread();
                

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();

                if (this.onConnected != null)
                    this.onConnected();

                Receive(client); // start recv 
            }
            catch (SocketException e)
            {
                if (this.onDisconnected != null)
                    this.onDisconnected(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject) ar.AsyncState;
                Socket client = state.workSocket;
                if(client!=null && !client.Connected)
                    return;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, bytesRead));

                    byte[] bsRead = new byte[bytesRead];
                    Array.Copy(state.buffer, 0, bsRead, 0, bytesRead);

                    this.lsRecvBytes.Enqueue(bsRead);

                    //Console.WriteLine("Read Raw Data = " + StringTools.Bin2Hex(bsRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);

                    //receiveDone.Set();
                }
                else
                {
                    this.Stop();
                    if (this.onDisconnected != null)
                        this.onDisconnected("Remote Computer had exit !!!");

                    // All the data has arrived; put it in response.  
                    //if (state.sb.Length > 1)
                    // {
                    //     response = state.sb.ToString();
                    // }
                    // Signal that all bytes have been received.  
                    //receiveDone.Set();
                }
            }
            catch (SocketException e)
            {
                if (e.SocketErrorCode == SocketError.ConnectionReset)
                {
                    
                }

                // to disconnect and release 
                this.Stop();
                if (this.onDisconnected != null)
                    this.onDisconnected(e.Message);

                Console.WriteLine(e.Message  + e.StackTrace);
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (this.onDisconnected != null)
                    this.onDisconnected("Disconnected");
            }
        }

        public void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.Unicode.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket) ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                //sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

  

        public void Send(string msg)
        {
            if (client == null)
                return;

            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.Unicode.GetBytes(msg);

            Send(byteData);

        }

        public void Send(byte[] buff)
        {
            if (client == null)
                return;

            // Begin sending the data to the remote device.  
            client.BeginSend(buff, 0, buff.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        public void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            client = null;
        }

    }
}